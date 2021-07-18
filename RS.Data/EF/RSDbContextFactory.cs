using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace RS.Data.EF
{
    class RSDbContextFactory : IDesignTimeDbContextFactory<RSDbContext>
    {
        public RSDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("RSDb");

            var optionsBuilder = new DbContextOptionsBuilder<RSDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new RSDbContext(optionsBuilder.Options);
        }
    }
}
