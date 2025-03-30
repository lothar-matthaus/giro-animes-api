using Giro.Animes.Shared.Middleware;
using Giro.Animes.Application.Extensions.IoC;
using Giro.Animes.Infra.Configs;
using Giro.Animes.Infra.Data.Extensions.IoC;
using Giro.Animes.Infra.Security;
using Giro.Animes.Shared.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura os serviços da API (Controllers, etc.)
builder.Services.AddControllers();

// Configura o acesso ao contexto HTTP
builder.Services.AddHttpContextAccessor();

// Adiciona as configurações da aplicação
builder.Services.AddAppConfig();

// Configura o usuário do contexto da requisição
builder.Services.AddApplicationUser();

// Configura a autenticação JWT
builder.Services.AddJwtAuthentication(builder.Configuration);

#region Contexts
builder.Services.AddWriteDbContext();
builder.Services.AddReadDbContext();
#endregion

#region Repositories
builder.Services.AddReadRepositories();
builder.Services.AddWriteRepositories();

builder.Services.ConfigureDomainServices();
builder.Services.ConfigureApplicationServices();

#endregion


#region Middlewares
builder.Services.AddTransient<ExceptionHandlingMiddleware>();
builder.Services.AddTransient<SaveChangesHandlingMiddleware>();
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region Middlewares
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<SaveChangesHandlingMiddleware>();
#endregion

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
