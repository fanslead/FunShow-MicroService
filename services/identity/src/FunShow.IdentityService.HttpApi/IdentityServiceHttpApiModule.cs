using Localization.Resources.AbpUi;
using FunShow.IdentityService.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace FunShow.IdentityService;

[DependsOn(
    typeof(IdentityServiceApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class IdentityServiceHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(IdentityServiceHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<IdentityServiceResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
