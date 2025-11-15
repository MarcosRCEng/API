using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI_Empresas.Application.DTOs.Requests;
using WebAPI_Empresas.Application.DTOs.Responses;

namespace WebAPI_Empresas.Application.Interfaces
{
    public interface IAtividadePrincipalService
    {
        Task<IEnumerable<AtividadePrincipalResponse>> GetAllAsync();
        Task<AtividadePrincipalResponse> GetByIdAsync(Guid id);
        Task<AtividadePrincipalResponse> CreateAsync(AtividadePrincipalRequest request);
        Task<bool> DeleteAsync(Guid id);
        Task ImportFromReceitaAsync(string cnpj);
    }
}
