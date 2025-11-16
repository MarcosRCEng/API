using System.Text.Json.Nodes;

namespace WebAPI_Empresas.Domain.ValueObjects
{
    public class Extra
    {
        // armazenamos JSON cru para flexibilidade futura
        public JsonObject? Data { get; private set; }

        protected Extra() { }

        public Extra(JsonObject? data)
        {
            Data = data;
        }
    }
}
