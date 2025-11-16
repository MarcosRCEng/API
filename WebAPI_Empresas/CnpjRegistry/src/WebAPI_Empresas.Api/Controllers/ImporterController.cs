using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI_Empresas.Application.Interfaces;

namespace WebAPI_Empresas.Api.Controllers
{
    [ApiController]
    [Route(""api/importer"")]
    public class ImporterController : ControllerBase
    {
        private readonly IImportadorReceitaService _importer;

        public ImporterController(IImportadorReceitaService importer)
        {
            _importer = importer;
        }

        [HttpPost(""import/{cnpj}"")]
        public async Task<IActionResult> Import(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj)) return BadRequest();
            await _importer.ImportarPorCnpjAsync(cnpj);
            return Ok();
        }
    }
}
