using System.IO;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Volo.Abp;


namespace FunShow.AdministrationService.EntityFrameworkCore.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
    * (like Add-Migration and Update-Database commands)
    * */
    public class AdministrationServiceDbContextFactory : IDesignTimeDbContextFactory<AdministrationServiceDbContext>
    {        
        private readonly string _connectionString;

        /* This constructor is used when you use EF Core tooling (e.g. Update-Database) */
        public AdministrationServiceDbContextFactory()
        {
            _connectionString = GetConnectionStringFromConfiguration();
        }

        /* This constructor is used by DbMigrator application */
        public AdministrationServiceDbContextFactory([NotNull] string connectionString)
        {
            Check.NotNullOrWhiteSpace(connectionString, nameof(connectionString));
            _connectionString = connectionString;
        }
        public AdministrationServiceDbContext CreateDbContext(string[] args)
        {
            AdministrationServiceEfCoreEntityExtensionMappings.Configure();

            var builder = new DbContextOptionsBuilder<AdministrationServiceDbContext>()
                .UseNpgsql(_connectionString, b =>
                {
                    b.MigrationsHistoryTable("__AdministrationService_Migrations");
                });

            return new AdministrationServiceDbContext(builder.Options);
        }

        private static string GetConnectionStringFromConfiguration()
        {
            return BuildConfiguration()
                .GetConnectionString(AdministrationServiceDbProperties.ConnectionStringName);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(
                    Path.Combine(
                        Directory.GetCurrentDirectory(),
                        $"..{Path.DirectorySeparatorChar}FunShow.AdministrationService.HttpApi.Host"
                    )
                )
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }

}