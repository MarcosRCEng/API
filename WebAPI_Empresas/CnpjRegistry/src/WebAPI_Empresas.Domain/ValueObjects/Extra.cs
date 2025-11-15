using System.Text.Json.Nodes;

namespace WebAPI_Empresas.Domain.ValueObjects
{
    public class Extra
    {
        public JsonObject? Data { get; private set; }

        protected Extra() { }

        public Extra(JsonObject? data)
        {
            Data = data;
        }
    }
}
