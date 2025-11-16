using System;

namespace WebAPI_Empresas.Domain.Entities
{
    public class Qsa
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; } = null!;
        public string Qual { get; private set; } = null!;

        protected Qsa() { }

        public Qsa(string nome, string qual)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Qual = qual;
        }
    }
}
