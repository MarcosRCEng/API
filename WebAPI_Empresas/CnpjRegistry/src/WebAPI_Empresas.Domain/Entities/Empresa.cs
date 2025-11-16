using System;
using System.Collections.Generic;
using WebAPI_Empresas.Domain.ValueObjects;

namespace WebAPI_Empresas.Domain.Entities
{
    public class Empresa
    {
        public Guid Id { get; private set; }
        public string Cnpj { get; private set; } = null!;
        public string Tipo { get; private set; } = null!;
        public DateTime? Abertura { get; private set; }
        public string Nome { get; private set; } = null!;
        public string? Fantasia { get; private set; }
        public string? Situacao { get; private set; }
        public string? Status { get; private set; }
        public DateTime? UltimaAtualizacao { get; private set; }

        // Value objects / owned
        public Endereco? Endereco { get; private set; }
        public AtividadePrincipal? AtividadePrincipal { get; private set; }

        // Collections
        private readonly List<AtividadeSecundaria> _atividadesSecundarias = new();
        public IReadOnlyCollection<AtividadeSecundaria> AtividadesSecundarias => _atividadesSecundarias.AsReadOnly();

        private readonly List<Qsa> _qsa = new();
        public IReadOnlyCollection<Qsa> Qsa => _qsa.AsReadOnly();

        public Simples? Simples { get; private set; }
        public Simei? Simei { get; private set; }
        public Billing? Billing { get; private set; }
        public Extra? Extra { get; private set; }

        protected Empresa() { }

        public Empresa(string cnpj, string tipo, DateTime? abertura, string nome)
        {
            Id = Guid.NewGuid();
            Cnpj = cnpj;
            Tipo = tipo;
            Abertura = abertura;
            Nome = nome;
            UltimaAtualizacao = DateTime.UtcNow;
        }

        // Updaters / Factory-like behavior
        public void SetFantasia(string? fantasia)
        {
            Fantasia = fantasia;
            Touch();
        }

        public void SetSituacao(string? situacao)
        {
            Situacao = situacao;
            Touch();
        }

        public void SetStatus(string? status)
        {
            Status = status;
            Touch();
        }

        public void SetUltimaAtualizacao(DateTime? dt)
        {
            UltimaAtualizacao = dt;
            Touch();
        }

        public void SetEndereco(Endereco endereco)
        {
            Endereco = endereco;
            Touch();
        }

        public void SetAtividadePrincipal(AtividadePrincipal atividade)
        {
            AtividadePrincipal = atividade;
            Touch();
        }

        public void AddAtividadeSecundaria(AtividadeSecundaria atividade)
        {
            if (atividade == null) return;
            _atividadesSecundarias.Add(atividade);
            Touch();
        }

        public void ClearAtividadesSecundarias()
        {
            _atividadesSecundarias.Clear();
            Touch();
        }

        public void AddQsa(Qsa socio)
        {
            if (socio == null) return;
            _qsa.Add(socio);
            Touch();
        }

        public void ClearQsa()
        {
            _qsa.Clear();
            Touch();
        }

        public void SetSimples(Simples simples)
        {
            Simples = simples;
            Touch();
        }

        public void SetSimei(Simei s)
        {
            Simei = s;
            Touch();
        }

        public void SetBilling(Billing billing)
        {
            Billing = billing;
            Touch();
        }

        public void SetExtra(Extra extra)
        {
            Extra = extra;
            Touch();
        }

        private void Touch()
        {
            UltimaAtualizacao = DateTime.UtcNow;
        }
    }
}
