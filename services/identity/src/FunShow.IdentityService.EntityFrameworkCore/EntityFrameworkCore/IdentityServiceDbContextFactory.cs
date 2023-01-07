using System.IO;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Volo.Abp;

namespace FunShow.IdentityService.EntityFrameworkCore.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
    * (like Add-Migration and Update-Database commands)
    * */
    public class IdentityServiceDbContextFactory : IDesignTimeDbContextFactory<IdentityServiceDbContext>
    {
        
        private readonly string _connectionString;

        /* This constructor is used when you use EF Core tooling (e.g. Update-Database) */
        public IdentityServiceDbContextFactory()
        {
            _connectionString = GetConnectionStringFromConfiguration();
        }

        /* This constructor is used by DbMigrator application */
        public IdentityServiceDbContextFactory([NotNull] string connectionString)
        {
            Check.NotNullOrWhiteSpace(connectionString, nameof(connectionString));
            _connectionString = connectionString;
        }
        public IdentityServiceDbContext CreateDbContext(string[] args)
        {
            IdentityServiceEfCoreEntityExtensionMappings.Configure();

            var builder = new DbContextOptionsBuilder<IdentityServiceDbContext>()
                .UseNpgsql(_connectionString, b =>
                {
                    b.MigrationsHistoryTable("__IdentityService_Migrations");
                });

            return new IdentityServiceDbContext(builder.Options);
        }

        private static string GetConnectionStringFromConfiguration()
        {
            return BuildConfiguration()
                .GetConnectionString(IdentityServiceDbProperties.ConnectionStringName);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(
                    Path.Combine(
                        Directory.GetCurrentDirectory(),
                        $"..{Path.DirectorySeparatorChar}FunShow.IdentityService.HttpApi.Host"
                    )
                )
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}