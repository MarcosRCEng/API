using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI_Empresas.Application.DTOs.Requests;
using WebAPI_Empresas.Application.DTOs.Responses;
using WebAPI_Empresas.Application.Interfaces;
using WebAPI_Empresas.Infrastructure.Repositories;

namespace WebAPI_Empresas.Application.Services
{
    public class AtividadePrincipalService : IAtividadePrincipalService
    {
        private readonly AtividadePrincipalRepository _repository;

        public AtividadePrincipalService(AtividadePrincipalRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AtividadePrincipalResponse>> GetAllAsync()
        {
            return new List<AtividadePrincipalResponse>();
        }

        public async Task<AtividadePrincipalResponse> GetByIdAsync(Guid id)
        {
            return new AtividadePrincipalResponse();
        }

        public async Task<AtividadePrincipalResponse> CreateAsync(AtividadePrincipalRequest request)
        {
            return new AtividadePrincipalResponse();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return true;
        }

        public async Task ImportFromReceitaAsync(string cnpj)
        {
            // TODO: implement import logic
        }
    }
}
