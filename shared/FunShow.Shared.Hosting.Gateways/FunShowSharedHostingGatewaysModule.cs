using FunShow.Shared.Hosting.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace FunShow.Shared.Hosting.Gateways;

[DependsOn(
        typeof(FunShowSharedHostingAspNetCoreModule)
    )]
public class FunShowSharedHostingGatewaysModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        
        context.Services.AddReverseProxy()
            .LoadFromConfig(configuration.GetSection("ReverseProxy"));
    }
}
