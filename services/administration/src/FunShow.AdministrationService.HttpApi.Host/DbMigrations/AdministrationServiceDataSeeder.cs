using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement;
using Volo.Abp.Uow;
using System.Linq;

namespace FunShow.AdministrationService.DbMigrations
{
    public class AdministrationServiceDataSeeder : ITransientDependency
    {
        private readonly ILogger<AdministrationServiceDataSeeder> _logger;
        private readonly IPermissionDefinitionManager _permissionDefinitionManager;
        private readonly IPermissionDataSeeder _permissionDataSeeder;
        private readonly ICurrentTenant _currentTenant;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public AdministrationServiceDataSeeder(
            ILogger<AdministrationServiceDataSeeder> logger,
            IPermissionDefinitionManager permissionDefinitionManager,
            IPermissionDataSeeder permissionDataSeeder,
            ICurrentTenant currentTenant,
            IUnitOfWorkManager unitOfWorkManager)
        {
            _logger = logger;
            _permissionDefinitionManager = permissionDefinitionManager;
            _permissionDataSeeder = permissionDataSeeder;
            _currentTenant = currentTenant;
            _unitOfWorkManager = unitOfWorkManager;
        }

        public async Task SeedAsync(Guid? tenantId = null)
        {
            using (_currentTenant.Change(tenantId))
            {
                using (var uow = _unitOfWorkManager.Begin(requiresNew: true, isTransactional: true))
                {
                    var multiTenancySide = tenantId == null
                        ? MultiTenancySides.Host
                        : MultiTenancySides.Tenant;

                    var permissionNames = (await _permissionDefinitionManager
                        .GetPermissionsAsync())
                        .Where(p => p.MultiTenancySide.HasFlag(multiTenancySide))
                        .Where(p => !p.Providers.Any() || p.Providers.Contains(RolePermissionValueProvider.ProviderName))
                        .Select(p => p.Name)
                        .ToArray();

                    _logger.LogInformation($"Seeding admin permissions.");
                    await _permissionDataSeeder.SeedAsync(
                        RolePermissionValueProvider.ProviderName,
                        "admin",
                        permissionNames,
                        tenantId
                    );

                    await uow.CompleteAsync();
                }
            }
        }
    }
}
