namespace WebAPI_Empresas.Domain.ValueObjects
{
    public class AtividadePrincipal
    {
        public string Code { get; private set; } = null!;
        public string Text { get; private set; } = null!;

        protected AtividadePrincipal() { }

        public AtividadePrincipal(string code, string text)
        {
            Code = code;
            Text = text;
        }
    }
}
