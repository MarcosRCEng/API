namespace WebAPI_Empresas.Domain.ValueObjects
{
    public class Endereco
    {
        public string Logradouro { get; private set; } = null!;
        public string Numero { get; private set; } = null!;
        public string Complemento { get; private set; } = null!;
        public string Cep { get; private set; } = null!;
        public string Bairro { get; private set; } = null!;
        public string Municipio { get; private set; } = null!;
        public string Uf { get; private set; } = null!;
        public string Telefone { get; private set; } = null!;
        public string Email { get; private set; } = null!;

        protected Endereco() { }

        public Endereco(
            string logradouro,
            string numero,
            string complemento,
            string cep,
            string bairro,
            string municipio,
            string uf,
            string telefone,
            string email)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Cep = cep;
            Bairro = bairro;
            Municipio = municipio;
            Uf = uf;
            Telefone = telefone;
            Email = email;
        }
    }
}
