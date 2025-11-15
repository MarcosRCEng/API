using System;
using System.Collections.Generic;
using WebAPI_Empresas.Domain.ValueObjects;

namespace WebAPI_Empresas.Domain.Entities
{
    public class Empresa
    {
        public Guid Id { get; private set; }
        public Cnpj Cnpj { get; private set; } = new Cnpj();
        public string Tipo { get; private set; } = string.Empty;
        public DateTime? Abertura { get; private set; }
        public string Nome { get; private set; } = string.Empty;
        public string Fantasia { get; private set; } = string.Empty;
        public string Porte { get; private set; } = string.Empty;
        public string NaturezaJuridica { get; private set; } = string.Empty;

        // Address is owned
        public Endereco? Endereco { get; private set; }

        // Activities
        public AtividadePrincipal? AtividadePrincipal { get; private set; }
        private readonly List<AtividadeSecundaria> _atividadesSecundarias = new();
        public IReadOnlyCollection<AtividadeSecundaria> AtividadesSecundarias => _atividadesSecundarias.AsReadOnly();

        // QSA
        private readonly List<Qsa> _qsa = new();
        public IReadOnlyCollection<Qsa> Qsa => _qsa.AsReadOnly();

        public string Municipio { get; private set; } = string.Empty;
        public string Bairro { get; private set; } = string.Empty;
        public string Uf { get; private set; } = string.Empty;
        public string Cep { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Telefone { get; private set; } = string.Empty;

        public DateTime? DataSituacao { get; private set; }
        public DateTime? UltimaAtualizacao { get; private set; }
        public string Status { get; private set; } = string.Empty;
        public string Efr { get; private set; } = string.Empty;
        public string MotivoSituacao { get; private set; } = string.Empty;
        public string SituacaoEspecial { get; private set; } = string.Empty;
        public DateTime? DataSituacaoEspecial { get; private set; }
        public decimal? CapitalSocial { get; private set; }

        public Simples? Simples { get; private set; }
        public Simei? Simei { get; private set; }
        public Extra? Extra { get; private set; }
        public Billing? Billing { get; private set; }

        protected Empresa() { }

        public Empresa(Cnpj cnpj, string tipo, DateTime? abertura, string nome)
        {
            Id = Guid.NewGuid();
            Cnpj = cnpj;
            Tipo = tipo ?? string.Empty;
            Abertura = abertura;
            Nome = nome ?? string.Empty;
            UltimaAtualizacao = DateTime.UtcNow;
        }

        // Updaters
        public void SetFantasia(string? fantasia) { Fantasia = fantasia ?? string.Empty; Touch(); }
        public void SetPorte(string? porte) { Porte = porte ?? string.Empty; Touch(); }
        public void SetNaturezaJuridica(string? nat) { NaturezaJuridica = nat ?? string.Empty; Touch(); }

        public void SetEndereco(Endereco endereco) { Endereco = endereco; Touch(); }
        public void SetAtividadePrincipal(AtividadePrincipal atividade) { AtividadePrincipal = atividade; Touch(); }
        public void AddAtividadeSecundaria(AtividadeSecundaria a) { if (a!=null) _atividadesSecundarias.Add(a); Touch(); }
        public void ClearAtividadesSecundarias() { _atividadesSecundarias.Clear(); Touch(); }

        public void AddQsa(Qsa socio) { if (socio!=null) _qsa.Add(socio); Touch(); }
        public void ClearQsa() { _qsa.Clear(); Touch(); }

        public void SetContato(string municipio, string bairro, string uf, string cep, string email, string telefone)
        {
            Municipio = municipio ?? string.Empty;
            Bairro = bairro ?? string.Empty;
            Uf = uf ?? string.Empty;
            Cep = cep ?? string.Empty;
            Email = email ?? string.Empty;
            Telefone = telefone ?? string.Empty;
            Touch();
        }

        public void SetSituacao(DateTime? dataSituacao, string status)
        {
            DataSituacao = dataSituacao;
            Status = status ?? string.Empty;
            Touch();
        }

        public void SetFinanceiro(decimal? capitalSocial)
        {
            CapitalSocial = capitalSocial;
            Touch();
        }

        public void SetSimples(Simples simples) { Simples = simples; Touch(); }
        public void SetSimei(Simei simei) { Simei = simei; Touch(); }
        public void SetExtra(Extra extra) { Extra = extra; Touch(); }
        public void SetBilling(Billing billing) { Billing = billing; Touch(); }

        private void Touch() => UltimaAtualizacao = DateTime.UtcNow;
    }
}
