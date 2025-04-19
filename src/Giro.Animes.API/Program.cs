using Asp.Versioning;
using Giro.Animes.Application.Extensions.IoC;
using Giro.Animes.Infra.Configs;
using Giro.Animes.Infra.Data.Extensions.IoC;
using Giro.Animes.Infra.Extensions;
using Giro.Animes.Infra.Extensions.IoC;
using Giro.Animes.Infra.Extensions.IoC.Security;
using Giro.Animes.Infra.Interfaces.Configs;
using Giro.Animes.Shared.Extensions.Authorization;
using Giro.Animes.Shared.Extensions.Swaggger;
using Giro.Animes.Shared.Filters;
using Giro.Animes.Shared.Middleware;
using Giro.Animes.Shared.Middlewares;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

// Configura o logging
builder.Logging.ClearProviders(); // Remove provedores padrão, se necessário
builder.Logging.AddConsole(); // Adiciona logs no console
builder.Logging.AddDebug(); // Adiciona logs no Debug (útil para desenvolvimento)


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Configura os serviços da API (Controllers, etc.)
builder.Services.AddControllers(options =>
{
    options.Filters.Add<NotificationResultFilter>();
    options.Filters.Add<SaveChangesResultFilter>();
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

builder.Services.AddApiVersioning(options =>
{
    IApiInfo apiInfo = new ApiInfo(builder.Configuration);

    if (apiInfo == null)
        throw new ArgumentNullException("As informações da API não foram encontradas nas variáveis de ambiente.");

    options.DefaultApiVersion = new ApiVersion(apiInfo.Version[0], apiInfo.Version[1]);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});

// Configura o acesso ao contexto HTTP
builder.Services.AddHttpContextAccessor();

// Adiciona as configurações da aplicação
builder.Services.AddApplicationUser();
builder.Services.AddAppConfig();

// Configura o usuário do contexto da requisição
// Configura o AutoMapper
builder.Services.AddSwaggerConfig(builder.Configuration);

// Configura a autenticação JWT
builder.Services.AddJwtAuthorization(builder.Configuration);

builder.Services.AddAuthorizationWithPolicies();
#region Contexts
builder.Services.AddGiroAnimesDbContext();
#endregion

#region Repositories
builder.Services.AddRepositories();
#endregion

#region Services
builder.Services.ConfigureDomainServices();
builder.Services.ConfigureApplicationServices();
builder.Services.AddServices();
#endregion

#region Middlewares
builder.Services.AddTransient<DomainEventsHandlingMiddleware>();
builder.Services.AddTransient<ExceptionHandlingMiddleware>();
#endregion

#region Eventos de domínio
builder.Services.AddDomainEvents();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.Logger.LogDebug("Configurando Swagger para o ambiente de desenvolvimento...");
    app.UseSwaggerConfig();
}

app.UseMiddleware<DomainEventsHandlingMiddleware>();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
