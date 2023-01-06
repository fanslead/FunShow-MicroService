using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using FunShow.LoggingService.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace FunShow.LoggingService;

[DependsOn(
    typeof(LoggingServiceApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class LoggingServiceHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(LoggingServiceHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<LoggingServiceResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
