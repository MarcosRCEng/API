using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebAPI_Empresas.Infrastructure.Services
{
    public class ReceitaWsClient
    {
        private readonly HttpClient _http;

        public ReceitaWsClient(HttpClient http)
        {
            _http = http ?? throw new ArgumentNullException(nameof(http));
            _http.Timeout = TimeSpan.FromSeconds(30);
        }

        public async Task<string> GetRawByCnpjAsync(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj)) throw new ArgumentException(""cnpj is required"", nameof(cnpj));
            var url = $""https://www.receitaws.com.br/v1/cnpj/{cnpj}"";
            var response = await _http.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
