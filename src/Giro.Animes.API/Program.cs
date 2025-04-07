using Giro.Animes.Application.Extensions.IoC;
using Giro.Animes.Infra.Data.Extensions.IoC;
using Giro.Animes.Infra.Extensions;
using Giro.Animes.Infra.Extensions.IoC;
using Giro.Animes.Infra.Extensions.IoC.Security;
using Giro.Animes.Shared.Extensions;
using Giro.Animes.Shared.Filters;
using Giro.Animes.Shared.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Configura os serviços da API (Controllers, etc.)
builder.Services.AddControllers(options =>
{
    options.Filters.Add<NotificationResultFilter>();
});

// Configura o acesso ao contexto HTTP
builder.Services.AddHttpContextAccessor();

// Adiciona as configurações da aplicação
builder.Services.AddApplicationUser();
builder.Services.AddAppConfig();

// Configura o usuário do contexto da requisição
// Configura o AutoMapper
builder.Services.AddSwaggerConfig();

// Configura a autenticação JWT
builder.Services.AddJwtAuthorization(builder.Configuration);

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
builder.Services.AddTransient<ExceptionHandlingMiddleware>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfig();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
