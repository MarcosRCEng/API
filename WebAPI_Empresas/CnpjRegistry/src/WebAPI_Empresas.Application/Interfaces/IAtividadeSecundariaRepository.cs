using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI_Empresas.Domain.Entities;

namespace WebAPI_Empresas.Application.Interfaces;

public interface IAtividadeSecundariaRepository
{
    Task<AtividadeSecundaria?> GetByIdAsync(Guid id);
    Task<IEnumerable<AtividadeSecundaria>> GetAllAsync();
    Task AddAsync(AtividadeSecundaria entity);
    Task UpdateAsync(AtividadeSecundaria entity);
    Task DeleteAsync(Guid id);
}
