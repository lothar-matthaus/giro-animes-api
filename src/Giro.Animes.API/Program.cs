using Giro.Animes.API.Middlewares;
using Giro.Animes.Application.Extensions.IoC;
using Giro.Animes.Infra.Data.Extensions.IoC;
using Giro.Animes.Infra.Extensions.Dependencies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura os servi�os da API (Controllers, etc.)
builder.Services.AddControllers();

// Adiciona as configura��es da aplica��o
builder.Services.AddAppConfig();

// Configura o usu�rio do contexto da requisi��o
builder.Services.AddApplicationUser();

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
#endregion

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
