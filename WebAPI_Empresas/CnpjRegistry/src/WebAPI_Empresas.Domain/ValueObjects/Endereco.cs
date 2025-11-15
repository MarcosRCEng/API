namespace WebAPI_Empresas.Domain.ValueObjects
{
    public class Endereco
    {
        public string Logradouro { get; private set; } = string.Empty;
        public string Numero { get; private set; } = string.Empty;
        public string Complemento { get; private set; } = string.Empty;
        public string Bairro { get; private set; } = string.Empty;
        public string Municipio { get; private set; } = string.Empty;
        public string Uf { get; private set; } = string.Empty;
        public string Cep { get; private set; } = string.Empty;

        protected Endereco() { }

        public Endereco(string logradouro, string numero, string complemento, string bairro, string municipio, string uf, string cep)
        {
            Logradouro = logradouro ?? string.Empty;
            Numero = numero ?? string.Empty;
            Complemento = complemento ?? string.Empty;
            Bairro = bairro ?? string.Empty;
            Municipio = municipio ?? string.Empty;
            Uf = uf ?? string.Empty;
            Cep = cep ?? string.Empty;
        }
    }
}
