using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Giro.Animes.Infra.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Giro.Animes.Infra.Data.Contexts.Factory
{
    public class GiroAnimesDbContextFactory : IDesignTimeDbContextFactory<GiroAnimesDbContext>
    {
        public GiroAnimesDbContext CreateDbContext(string[] args)
        {
            // Lê o appsettings.json da pasta da API
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../Giro.Animes.API");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.Development.json", optional: true)
                .Build();

            var connectionString = configuration.GetSection("DataBaseConfig:ConnectionString").Value ?? "";

            var optionsBuilder = new DbContextOptionsBuilder<GiroAnimesDbContext>();
            optionsBuilder.UseNpgsql(connectionString);


            return new GiroAnimesDbContext(optionsBuilder.Options, null);
        }
    }
}
