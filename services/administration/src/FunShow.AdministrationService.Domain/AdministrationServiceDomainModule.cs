using Volo.Abp.Domain;
using Volo.Abp.Modularity;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Localization;
using Volo.Abp.PermissionManagement;
using Volo.Abp.PermissionManagement.Identity;
using Volo.Abp.PermissionManagement.OpenIddict;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.Identity;

namespace FunShow.AdministrationService;
[DependsOn(
typeof(AbpDddDomainModule),
    typeof(AbpIdentityDomainModule),
    typeof(AdministrationServiceDomainSharedModule),
    typeof(AbpPermissionManagementDomainModule),
    typeof(AbpTenantManagementDomainModule),
    typeof(AbpFeatureManagementDomainModule),
    typeof(AbpSettingManagementDomainModule),
    typeof(AbpPermissionManagementDomainOpenIddictModule),
    typeof(AbpPermissionManagementDomainIdentityModule)
)]
public class AdministrationServiceDomainModule : AbpModule
{

}
