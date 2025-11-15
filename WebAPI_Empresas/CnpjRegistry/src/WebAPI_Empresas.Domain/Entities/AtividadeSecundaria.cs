namespace WebAPI_Empresas.Domain.Entities
{
    public class AtividadeSecundaria
    {
        public int Id { get; private set; }
        public string Code { get; private set; } = string.Empty;
        public string Text { get; private set; } = string.Empty;

        protected AtividadeSecundaria() { }

        public AtividadeSecundaria(string code, string text)
        {
            Code = code ?? string.Empty;
            Text = text ?? string.Empty;
        }
    }
}
