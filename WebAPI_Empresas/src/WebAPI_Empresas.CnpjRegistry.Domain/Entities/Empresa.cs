namespace CnpjRegistry.Domain.Entities
{
    public class Empresa
    {
        public Guid Id { get; private set; }
        public string Cnpj { get; private set; }
        public string Nome { get; private set; }

        protected Empresa() {}

        public Empresa(string cnpj, string nome)
        {
            Id = Guid.NewGuid();
            Cnpj = cnpj;
            Nome = nome;
        }
    }
}
