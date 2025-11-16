using System;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json.Nodes;
using WebAPI_Empresas.Application.Interfaces;
using WebAPI_Empresas.Infrastructure.Services;
using WebAPI_Empresas.Domain.Interfaces;

namespace WebAPI_Empresas.Application.Services
{
    public class ImportadorReceitaService : IImportadorReceitaService
    {
        private readonly ReceitaWsClient _receitaClient;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IAtividadePrincipalRepository _atividadePrincipalRepository;
        private readonly IAtividadeSecundariaRepository _atividadeSecundariaRepository;
        private readonly IQsaRepository _qsaRepository;

        public ImportadorReceitaService(
            ReceitaWsClient receitaClient,
            IEmpresaRepository empresaRepository,
            IAtividadePrincipalRepository atividadePrincipalRepository,
            IAtividadeSecundariaRepository atividadeSecundariaRepository,
            IQsaRepository qsaRepository)
        {
            _receitaClient = receitaClient;
            _empresaRepository = empresaRepository;
            _atividadePrincipalRepository = atividadePrincipalRepository;
            _atividadeSecundariaRepository = atividadeSecundariaRepository;
            _qsaRepository = qsaRepository;
        }

        public async Task ImportarPorCnpjAsync(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj)) throw new ArgumentException(""cnpj is required"", nameof(cnpj));

            // 1) fetch raw JSON
            var raw = await _receitaClient.GetRawByCnpjAsync(cnpj);

            // 2) parse as JsonNode for flexible mapping
            JsonNode? root = null;
            try
            {
                root = JsonNode.Parse(raw);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(""Failed to parse JSON from ReceitaWS"", ex);
            }

            if (root == null) throw new InvalidOperationException(""Empty JSON from ReceitaWS"");

            // 3) map basic Empresa fields
            var cnpjValue = root[""cnpj""]?.ToString() ?? cnpj;
            var nome = root[""nome""]?.ToString() ?? string.Empty;
            var fantasia = root[""fantasia""]?.ToString() ?? string.Empty;
            var tipo = root[""tipo""]?.ToString() ?? string.Empty;
            DateTime? abertura = null;
            if (DateTime.TryParse(root[""abertura""]?.ToString(), out var dtAbertura)) abertura = dtAbertura;

            // Upsert Empresa by CNPJ
            var existing = await _empresaRepository.GetByCnpjAsync(cnpjValue);

            Domain.Entities.Empresa empresa = null;

            if (existing == null)
            {
                // create new Empresa
                empresa = new Domain.Entities.Empresa(
                    new Domain.ValueObjects.Cnpj(cnpjValue),
                    tipo,
                    abertura,
                    nome);
                empresa.SetFantasia(fantasia);
            }
            else
            {
                // update existing Empresa (simple update, expand as needed)
                empresa = existing;
                empresa.SetFantasia(fantasia);
                empresa.SetSituacao(null, root[""status""]?.ToString() ?? string.Empty);
                empresa.SetUltimaAtualizacao(DateTime.UtcNow);
            }

            // 4) AtividadePrincipal (first item)
            var ap = root[""atividade_principal""]?.AsArray();
            if (ap != null && ap.Count > 0)
            {
                var item = ap[0];
                var code = item[""code""]?.ToString() ?? string.Empty;
                var text = item[""text""]?.ToString() ?? string.Empty;

                var atividadePrincipal = new Domain.Entities.AtividadePrincipal(code, text);

                // simplistic upsert: add to empresa and save via repository later
                empresa.SetAtividadePrincipal(atividadePrincipal);
            }

            // 5) Atividades secundarias
            var asArray = root[""atividades_secundarias""]?.AsArray();
            if (asArray != null)
            {
                empresa.ClearAtividadesSecundarias();
                foreach (var a in asArray)
                {
                    var code = a[""code""]?.ToString() ?? string.Empty;
                    var text = a[""text""]?.ToString() ?? string.Empty;
                    var atSec = new Domain.Entities.AtividadeSecundaria(code, text);
                    empresa.AddAtividadeSecundaria(atSec);
                }
            }

            // 6) QSA (socios)
            var qsaArray = root[""qsa""]?.AsArray();
            if (qsaArray != null)
            {
                empresa.ClearQsa();
                foreach (var s in qsaArray)
                {
                    var nomeSoc = s[""nome""]?.ToString() ?? string.Empty;
                    var qual = s[""qual""]?.ToString() ?? string.Empty;
                    var qsa = new Domain.Entities.Qsa(nomeSoc, qual);
                    empresa.AddQsa(qsa);
                }
            }

            // 7) Simples / Simei / Billing / Extra
            var simplesNode = root[""simples""];
            if (simplesNode != null)
            {
                bool optante = simplesNode[""optante""]?.GetValue<bool>() ?? false;
                DateTime? dataOpcao = null;
                DateTime.TryParse(simplesNode[""data_opcao""]?.ToString(), out var d1);
                if (d1 != [DateTime]::MinValue) dataOpcao = d1;
                DateTime? ultima = null;
                DateTime.TryParse(simplesNode[""ultima_atualizacao""]?.ToString(), out var d2);
                if (d2 != [DateTime]::MinValue) ultima = d2;

                var simples = new Domain.ValueObjects.Simples(optante, dataOpcao, null, ultima);
                empresa.SetSimples(simples);
            }

            var simeiNode = root[""simei""];
            if (simeiNode != null)
            {
                bool optante = simeiNode[""optante""]?.GetValue<bool>() ?? false;
                DateTime? ultima = null;
                DateTime.TryParse(simeiNode[""ultima_atualizacao""]?.ToString(), out var d3);
                if (d3 != [DateTime]::MinValue) ultima = d3;

                var simei = new Domain.ValueObjects.Simei(optante, null, null, ultima);
                empresa.SetSimei(simei);
            }

            var billingNode = root[""billing""];
            if (billingNode != null)
            {
                bool free = billingNode[""free""]?.GetValue<bool>() ?? false;
                bool database = billingNode[""database""]?.GetValue<bool>() ?? false;
                var billing = new Domain.ValueObjects.Billing(free, database);
                empresa.SetBilling(billing);
            }

            // Extra: store raw JSON as JsonObject
            try
            {
                var jsonObj = JsonNode.Parse(raw)?.AsObject();
                var extra = new Domain.ValueObjects.Extra(jsonObj);
                empresa.SetExtra(extra);
            }
            catch
            {
                // ignore
            }

            // 8) Persist (upsert)
            if (existing == null)
            {
                await _empresaRepository.AddAsync(empresa);
            }
            else
            {
                await _empresaRepository.UpdateAsync(empresa);
            }

            await _empresaRepository.SaveChangesAsync();
        }
    }
}
