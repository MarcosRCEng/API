using System;

namespace WebAPI_Empresas.Domain.Entities
{
    public class AtividadeSecundaria
    {
        public Guid Id { get; private set; }
        public string Code { get; private set; } = null!;
        public string Text { get; private set; } = null!;

        protected AtividadeSecundaria() { }

        public AtividadeSecundaria(string code, string text)
        {
            Id = Guid.NewGuid();
            Code = code;
            Text = text;
        }
    }
}
