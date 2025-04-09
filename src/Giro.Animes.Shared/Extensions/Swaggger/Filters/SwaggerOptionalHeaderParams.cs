using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giro.Animes.Shared.Extensions.Swaggger.Filters
{
    public class SwaggerOptionalHeaderParams : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "Interface-Language",
                In = ParameterLocation.Header,
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Default = new OpenApiString("en-US")
                },
                Description = "Idioma de interface padrão para usuários sem contas"
            });

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "Audio-Anime-Languages",
                In = ParameterLocation.Header,
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Default = new OpenApiString("en-US")
                },
                Description = "Idiomas de áudio padrão para usuários sem contas"
            });

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "Subtitle-Anime-Languages",
                In = ParameterLocation.Header,
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Default = new OpenApiString("en-US")
                },
                Description = "Idiomas de legendas padrão para usuários sem contas"
            });
        }
    }
}
