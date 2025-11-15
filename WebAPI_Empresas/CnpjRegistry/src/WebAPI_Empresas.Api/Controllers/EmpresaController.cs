using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebAPI_Empresas.Application.DTOs.Requests;
using WebAPI_Empresas.Application.Interfaces;

namespace WebAPI_Empresas.Api.Controllers
{
    [ApiController]
    [Route(""api/[controller]"")]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaService _service;

        public EmpresaController(IEmpresaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet(""{id}"")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmpresaRequest request)
        {
            return Ok(await _service.CreateAsync(request));
        }

        [HttpDelete(""{id}"")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _service.DeleteAsync(id));
        }

        [HttpPost(""import/{cnpj}"")]
        public async Task<IActionResult> Import(string cnpj)
        {
            await _service.ImportFromReceitaAsync(cnpj);
            return Ok();
        }
    }
}
