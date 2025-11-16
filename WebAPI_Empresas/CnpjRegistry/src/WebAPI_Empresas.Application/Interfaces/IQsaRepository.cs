using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI_Empresas.Domain.Entities;

namespace WebAPI_Empresas.Application.Interfaces;

public interface IQsaRepository
{
    Task<Qsa?> GetByIdAsync(Guid id);
    Task<IEnumerable<Qsa>> GetAllAsync();
    Task AddAsync(Qsa entity);
    Task UpdateAsync(Qsa entity);
    Task DeleteAsync(Guid id);
}
