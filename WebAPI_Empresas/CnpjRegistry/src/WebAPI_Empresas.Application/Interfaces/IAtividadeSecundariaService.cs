using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI_Empresas.Application.DTOs.Requests;
using WebAPI_Empresas.Application.DTOs.Responses;

namespace WebAPI_Empresas.Application.Interfaces
{
    public interface IAtividadeSecundariaService
    {
        Task<IEnumerable<AtividadeSecundariaResponse>> GetAllAsync();
        Task<AtividadeSecundariaResponse> GetByIdAsync(Guid id);
        Task<AtividadeSecundariaResponse> CreateAsync(AtividadeSecundariaRequest request);
        Task<bool> DeleteAsync(Guid id);
        Task ImportFromReceitaAsync(string cnpj);
    }
}
