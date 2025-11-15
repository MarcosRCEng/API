namespace WebAPI_Empresas.Domain.ValueObjects
{
    public record Cnpj
    {
        public string Value { get; init; } = string.Empty;

        public Cnpj() { }

        public Cnpj(string value)
        {
            Value = value?.Trim() ?? string.Empty;
        }

        public override string ToString() => Value;
    }
}
