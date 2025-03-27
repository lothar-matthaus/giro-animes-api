using Giro.Animes.Application;
using Giro.Animes.Application.Extensions.IoC;
using Giro.Animes.Application.Interfaces;
using Giro.Animes.Infra.Configs;
using Giro.Animes.Infra.Data.Extensions.IoC;
using Giro.Animes.Infra.Extensions.Dependencies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura os serviços da API (Controllers, etc.)
builder.Services.AddControllers();

// Adiciona as configurações da aplicação
builder.Services.AddAppConfig();

// Configura o usuário do contexto da requisição
builder.Services.AddApplicationUser();

#region Contexts
builder.Services.AddWriteDbContext();
builder.Services.AddReadDbContext();
#endregion

#region Repositories
builder.Services.AddReadRepositories();
builder.Services.AddWriteRepositories();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
