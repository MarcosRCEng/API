using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI_Empresas.Domain.Entities;

namespace WebAPI_Empresas.Application.Interfaces;

public interface IAtividadePrincipalRepository
{
    Task<AtividadePrincipal?> GetByIdAsync(Guid id);
    Task<IEnumerable<AtividadePrincipal>> GetAllAsync();
    Task AddAsync(AtividadePrincipal entity);
    Task UpdateAsync(AtividadePrincipal entity);
    Task DeleteAsync(Guid id);
}
