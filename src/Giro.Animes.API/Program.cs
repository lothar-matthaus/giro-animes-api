using Giro.Animes.Application.Extensions.IoC;
using Giro.Animes.Infra.Configs;
using Giro.Animes.Infra.Data.Extensions.IoC;
using Giro.Animes.Infra.Extensions.IoC;
using Giro.Animes.Infra.Security;
using Giro.Animes.Shared.Middleware;
using Giro.Animes.Shared.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura os servi�os da API (Controllers, etc.)
builder.Services.AddControllers();

// Configura o acesso ao contexto HTTP
builder.Services.AddHttpContextAccessor();

// Adiciona as configura��es da aplica��o
builder.Services.AddAppConfig();

// Configura o usu�rio do contexto da requisi��o
builder.Services.AddApplicationUser();

// Configura a autentica��o JWT
builder.Services.AddJwtAuthentication(builder.Configuration);

#region Contexts
builder.Services.AddWriteDbContext();
builder.Services.AddReadDbContext();
#endregion

#region Repositories
builder.Services.AddReadRepositories();
builder.Services.AddWriteRepositories();
#endregion

#region Services
builder.Services.ConfigureDomainServices();
builder.Services.ConfigureApplicationServices();
builder.Services.AddServices();
#endregion

#region Middlewares
builder.Services.AddTransient<SaveChangesHandlingMiddleware>();
builder.Services.AddTransient<ExceptionHandlingMiddleware>();
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region Middlewares
app.UseMiddleware<SaveChangesHandlingMiddleware>();
app.UseMiddleware<ExceptionHandlingMiddleware>();
#endregion

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
