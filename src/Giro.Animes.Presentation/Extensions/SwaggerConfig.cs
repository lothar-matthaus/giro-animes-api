
using Giro.Animes.Infra.Interfaces.Configs;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Giro.Animes.Shared.Extensions
{
    public static class SwaggerConfig
    {
        /// <summary>
        /// Configura o Swagger para a API.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            // TODO: Remover o uso do service provider aqui, pois isso pode causar problemas de desempenho e circularidade.
            IApiInfo apiInfo = services.BuildServiceProvider().GetRequiredService<IApiInfo>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Nome da sua API",
                    Version = "v1",
                    Description = "Descrição da sua API",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Seu Nome",
                        Email = "seuemail@example.com",
                        Url = new Uri("https://example.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Licença da API",
                        Url = new Uri("https://example.com/license")
                    }
                });

                // Adiciona a definição de segurança para o Bearer Token
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Insira o token JWT desta forma: Bearer {seu token}",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                        }
                });

                // Adiciona comentários XML (se existirem) para documentação
                var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFile);
                if (System.IO.File.Exists(xmlPath))
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ScreenSound API v1");
                c.RoutePrefix = string.Empty;
            });

            return app;
        }
    }
}
