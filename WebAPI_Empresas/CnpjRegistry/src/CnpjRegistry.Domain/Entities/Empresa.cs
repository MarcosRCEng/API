using CnpjRegistry.Domain.ValueObjects;

namespace CnpjRegistry.Domain.Entities;

public class Empresa : AggregateRoot
{
    public Cnpj Cnpj { get; private set; }
    public string RazaoSocial { get; private set; }
    public string NomeFantasia { get; private set; }
    public Endereco Endereco { get; private set; }
    public ICollection<AtividadeSecundaria> AtividadesSecundarias { get; private set; } = new List<AtividadeSecundaria>();
    public ICollection<Qsa> Qsa { get; private set; } = new List<Qsa>();

    public Empresa(Cnpj cnpj, string razaoSocial, string nomeFantasia, Endereco endereco)
    {
        Cnpj = cnpj;
        RazaoSocial = razaoSocial;
        NomeFantasia = nomeFantasia;
        Endereco = endereco;
    }
}
