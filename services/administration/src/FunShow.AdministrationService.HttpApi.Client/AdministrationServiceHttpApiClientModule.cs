using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.FeatureManagement;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;

namespace FunShow.AdministrationService;

[DependsOn(
    typeof(AbpPermissionManagementHttpApiClientModule),
    typeof(AbpFeatureManagementHttpApiClientModule),
    typeof(AbpSettingManagementHttpApiClientModule),
    typeof(AdministrationServiceApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class AdministrationServiceHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(AdministrationServiceApplicationContractsModule).Assembly,
            AdministrationServiceRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AdministrationServiceHttpApiClientModule>();
        });

    }
}
