using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;

namespace FunShow.IdentityService.DbMigrations;

public class IdentityServiceDataSeeder : ITransientDependency
{
    private readonly ILogger<IdentityServiceDataSeeder> _logger;
    private readonly IIdentityDataSeeder _identityDataSeeder;
    private readonly OpenIddictDataSeeder _openIddictDataSeeder;
    private readonly ICurrentTenant _currentTenant;
    

    public IdentityServiceDataSeeder(
        IIdentityDataSeeder identityDataSeeder,
        OpenIddictDataSeeder openIddictDataSeeder,
        ICurrentTenant currentTenant,
        ILogger<IdentityServiceDataSeeder> logger)
    {
        _identityDataSeeder = identityDataSeeder;
        _openIddictDataSeeder = openIddictDataSeeder;
        _currentTenant = currentTenant;
        _logger = logger;
    }

    public async Task SeedAsync()
    {
        try
        {
            _logger.LogInformation($"Seeding IdentityServer data...");
            await _openIddictDataSeeder.SeedAsync();
            _logger.LogInformation($"Seeding Identity data...");
            await _identityDataSeeder.SeedAsync(
                IdentityServiceDbProperties.DefaultAdminEmailAddress,
                IdentityServiceDbProperties.DefaultAdminPassword
            );
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            throw;
        }
    }

    public async Task SeedAsync(Guid? tenantId, string adminEmail, string adminPassword)
    {
        try
        {
            using (_currentTenant.Change(tenantId))
            {
                if (tenantId == null)
                {
                    _logger.LogInformation($"Seeding IdentityServer data...");
                    await _openIddictDataSeeder.SeedAsync();
                }

                _logger.LogInformation($"Seeding Identity data...");
                await _identityDataSeeder.SeedAsync(
                    adminEmail,
                    adminPassword,
                    tenantId
                );
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            throw;
        }
    }
}