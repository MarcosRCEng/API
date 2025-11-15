using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI_Empresas.Application.DTOs.Requests;
using WebAPI_Empresas.Application.DTOs.Responses;
using WebAPI_Empresas.Application.Interfaces;
using WebAPI_Empresas.Infrastructure.Repositories;

namespace WebAPI_Empresas.Application.Services
{
    public class QsaService : IQsaService
    {
        private readonly QsaRepository _repository;

        public QsaService(QsaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<QsaResponse>> GetAllAsync()
        {
            return new List<QsaResponse>();
        }

        public async Task<QsaResponse> GetByIdAsync(Guid id)
        {
            return new QsaResponse();
        }

        public async Task<QsaResponse> CreateAsync(QsaRequest request)
        {
            return new QsaResponse();
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
