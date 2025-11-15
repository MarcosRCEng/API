using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI_Empresas.Application.DTOs.Requests;
using WebAPI_Empresas.Application.DTOs.Responses;

namespace WebAPI_Empresas.Application.Interfaces
{
    public interface IQsaService
    {
        Task<IEnumerable<QsaResponse>> GetAllAsync();
        Task<QsaResponse> GetByIdAsync(Guid id);
        Task<QsaResponse> CreateAsync(QsaRequest request);
        Task<bool> DeleteAsync(Guid id);
        Task ImportFromReceitaAsync(string cnpj);
    }
}
