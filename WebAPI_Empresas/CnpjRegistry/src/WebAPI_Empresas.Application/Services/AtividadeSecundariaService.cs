using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI_Empresas.Application.DTOs.Requests;
using WebAPI_Empresas.Application.DTOs.Responses;
using WebAPI_Empresas.Application.Interfaces;
using WebAPI_Empresas.Infrastructure.Repositories;

namespace WebAPI_Empresas.Application.Services
{
    public class AtividadeSecundariaService : IAtividadeSecundariaService
    {
        private readonly AtividadeSecundariaRepository _repository;

        public AtividadeSecundariaService(AtividadeSecundariaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AtividadeSecundariaResponse>> GetAllAsync()
        {
            return new List<AtividadeSecundariaResponse>();
        }

        public async Task<AtividadeSecundariaResponse> GetByIdAsync(Guid id)
        {
            return new AtividadeSecundariaResponse();
        }

        public async Task<AtividadeSecundariaResponse> CreateAsync(AtividadeSecundariaRequest request)
        {
            return new AtividadeSecundariaResponse();
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
