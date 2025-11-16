using Microsoft.EntityFrameworkCore;
using WebAPI_Empresas.CnpjRegistry.Infrastructure.Context;
using WebAPI_Empresas.CnpjRegistry.Application;
using WebAPI_Empresas.CnpjRegistry.Infrastructure;
using WebAPI_Empresas.CnpjRegistry.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpClient("ReceitaWS", client =>
{
    client.BaseAddress = new Uri("https://brasilapi.com.br/api/cnpj/v1/");
});

builder.Services.AddScoped<ICnpjImportService, CnpjImportService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();




