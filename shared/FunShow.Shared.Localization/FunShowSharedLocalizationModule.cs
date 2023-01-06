using FunShow.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace FunShow.Shared.Localization;

[DependsOn(
    typeof(AbpValidationModule)
    )]
public class FunShowSharedLocalizationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<FunShowSharedLocalizationModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<FunShowResource>("en")
                .AddBaseTypes(
                    typeof(AbpValidationResource)
                ).AddVirtualJson("/Localization/FunShow");

            options.DefaultResourceType = typeof(FunShowResource);
        });
    }
}

