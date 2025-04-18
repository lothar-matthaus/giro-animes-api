
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Giro.Animes.Shared.Extensions
{
    public class FileUploadOperation : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var fileParams = context.ApiDescription.ParameterDescriptions
                .Where(p => p.Type == typeof(IFormFile) || (p.Type.IsGenericType && p.Type.GetGenericTypeDefinition() == typeof(List<>) && p.Type.GetGenericArguments()[0] == typeof(IFormFile)))
                .ToList();

            foreach (var param in fileParams)
            {
                var fileParam = operation.Parameters.FirstOrDefault(p => p.Name == param.Name);
                if (fileParam != null)
                {
                    fileParam.Content.Clear();
                    fileParam.Content.Add("multipart/form-data", new OpenApiMediaType { Schema = new OpenApiSchema { Type = "string", Format = "binary" } });
                }
            }
        }
    }
}
