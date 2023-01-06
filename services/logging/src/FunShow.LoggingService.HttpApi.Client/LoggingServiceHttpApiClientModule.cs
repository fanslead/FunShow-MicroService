using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace FunShow.LoggingService;

[DependsOn(
    typeof(LoggingServiceApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class LoggingServiceHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(typeof(LoggingServiceApplicationContractsModule).Assembly,
            LoggingServiceRemoteServiceConsts.RemoteServiceName);

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<LoggingServiceHttpApiClientModule>();
        });
    }
}
