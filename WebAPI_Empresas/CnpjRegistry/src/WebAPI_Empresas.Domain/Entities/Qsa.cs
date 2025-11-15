namespace WebAPI_Empresas.Domain.Entities
{
    public class Qsa
    {
        public int Id { get; private set; }
        public string Nome { get; private set; } = string.Empty;
        public string Qual { get; private set; } = string.Empty;

        protected Qsa() { }

        public Qsa(string nome, string qual)
        {
            Nome = nome ?? string.Empty;
            Qual = qual ?? string.Empty;
        }
    }
}
