using Giro.Animes.Infra.Configs;
using Giro.Animes.Infra.Interfaces.Configs;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Giro.Animes.Shared.Extensions.Swaggger
{
    public static class SwaggerConfig
    {
        /// <summary>
        /// Configura o Swagger para a API.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services, IConfiguration configuration)
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            IApiInfo apiInfo = new ApiInfo(configuration, assembly);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = apiInfo.Name,
                    Version = apiInfo.Version,
                    Description = apiInfo.Description,
                    TermsOfService = new Uri("https://giroanimes.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Lothar Matthaus",
                        Email = "contato@giroanimes.com",
                        Url = new Uri("https://giroanimes.com/contato")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Licença da API",
                        Url = new Uri("https://example.com/license")
                    }
                });
                // Define o esquema de segurança
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header usando o esquema Bearer. Ex: 'Bearer {token}'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                // Aplica o esquema globalmente
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });

                // Adiciona comentários XML (se existirem) para documentação
                var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                if (File.Exists(xmlPath))
                {
                    c.IncludeXmlComments(xmlPath);
                }
            });

            return services;
        }
        public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app)
        {
            IApiInfo apiInfo = app.ApplicationServices.GetRequiredService<IApiInfo>();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", apiInfo.Name);
                c.RoutePrefix = string.Empty;
            });

            return app;
        }
    }
}
