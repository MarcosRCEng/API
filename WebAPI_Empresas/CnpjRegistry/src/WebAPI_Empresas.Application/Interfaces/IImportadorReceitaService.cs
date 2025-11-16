using System.Threading.Tasks;

namespace WebAPI_Empresas.Application.Interfaces
{
    public interface IImportadorReceitaService
    {
        Task ImportarPorCnpjAsync(string cnpj);
    }
}
