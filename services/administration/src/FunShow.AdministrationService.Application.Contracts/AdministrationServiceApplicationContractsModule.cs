using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;
using Volo.Abp.FeatureManagement;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace FunShow.AdministrationService;
[DependsOn(
    typeof(AbpPermissionManagementApplicationContractsModule),
    typeof(AbpFeatureManagementApplicationContractsModule),
    typeof(AbpSettingManagementApplicationContractsModule),
    typeof(AbpTenantManagementApplicationContractsModule),
    typeof(AdministrationServiceDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class AdministrationServiceApplicationContractsModule : AbpModule
{

}
