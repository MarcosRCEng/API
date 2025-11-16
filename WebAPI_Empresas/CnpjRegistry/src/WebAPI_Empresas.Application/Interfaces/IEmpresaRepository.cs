using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI_Empresas.Domain.Entities;

namespace WebAPI_Empresas.Application.Interfaces;

public interface IEmpresaRepository
{
    Task<Empresa?> GetByIdAsync(Guid id);
    Task<IEnumerable<Empresa>> GetAllAsync();
    Task AddAsync(Empresa entity);
    Task UpdateAsync(Empresa entity);
    Task DeleteAsync(Guid id);
}
