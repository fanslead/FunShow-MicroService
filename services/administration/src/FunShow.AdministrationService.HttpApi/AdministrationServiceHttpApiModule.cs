using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using FunShow.AdministrationService.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.FeatureManagement;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace FunShow.AdministrationService;
[DependsOn(
    typeof(AbpPermissionManagementHttpApiModule),
    typeof(AbpFeatureManagementHttpApiModule),
    typeof(AbpSettingManagementHttpApiModule),
    typeof(AbpTenantManagementHttpApiModule),
    typeof(AdministrationServiceApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class AdministrationServiceHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(AdministrationServiceHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<AdministrationServiceResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
