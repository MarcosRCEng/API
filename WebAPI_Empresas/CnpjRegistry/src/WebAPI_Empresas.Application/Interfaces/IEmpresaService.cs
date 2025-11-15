using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI_Empresas.Application.DTOs.Requests;
using WebAPI_Empresas.Application.DTOs.Responses;

namespace WebAPI_Empresas.Application.Interfaces
{
    public interface IEmpresaService
    {
        Task<IEnumerable<EmpresaResponse>> GetAllAsync();
        Task<EmpresaResponse> GetByIdAsync(Guid id);
        Task<EmpresaResponse> CreateAsync(EmpresaRequest request);
        Task<bool> DeleteAsync(Guid id);
        Task ImportFromReceitaAsync(string cnpj);
    }
}
