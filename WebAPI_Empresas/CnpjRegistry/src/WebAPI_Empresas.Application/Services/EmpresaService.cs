using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI_Empresas.Application.DTOs.Requests;
using WebAPI_Empresas.Application.DTOs.Responses;
using WebAPI_Empresas.Application.Interfaces;
using WebAPI_Empresas.Infrastructure.Repositories;

namespace WebAPI_Empresas.Application.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly EmpresaRepository _repository;

        public EmpresaService(EmpresaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EmpresaResponse>> GetAllAsync()
        {
            return new List<EmpresaResponse>();
        }

        public async Task<EmpresaResponse> GetByIdAsync(Guid id)
        {
            return new EmpresaResponse();
        }

        public async Task<EmpresaResponse> CreateAsync(EmpresaRequest request)
        {
            return new EmpresaResponse();
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
