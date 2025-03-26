using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Giro.Animes.Infra.Data.Extensions
{
    internal static class DbContextExtension
    {
        public static void ToSnakeCase(this DbContext dbContext, ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                // Configura o nome da tabela para usar snake_case
                entity.SetTableName(FormatToSnakeCase(entity.GetTableName()));

                // Configura o nome das colunas para usar snake_case
                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(FormatToSnakeCase(property.GetColumnName()));
                }

                // Configura o nome das chaves estrangeiras para usar snake_case
                foreach (var key in entity.GetForeignKeys())
                {
                    key.SetConstraintName(FormatToSnakeCase(key.GetConstraintName()));
                }

                // Configura os nomes das chaves primárias para usar snake_case
                foreach (var key in entity.GetKeys())
                {
                    key.SetName(FormatToSnakeCase(key.GetName()));
                }
            }

            string FormatToSnakeCase(string name)
            {
                if (string.IsNullOrEmpty(name))
                    return name;

                var regex = new Regex(@"([a-z0-9])([A-Z])");
                var snakeCaseName = regex.Replace(name, "$1_$2").ToLowerInvariant();

                Console.WriteLine($"Alterado [{name}] para [{snakeCaseName}]");
                return snakeCaseName;
            }
        }
    }
}
