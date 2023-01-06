using Medallion.Threading;
using Medallion.Threading.Redis;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using FunShow.AdministrationService.EntityFrameworkCore;
using FunShow.Shared.Hosting.AspNetCore;
using StackExchange.Redis;
using Volo.Abp.AspNetCore.MultiTenancy;
using Volo.Abp.BackgroundJobs.RabbitMQ;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.DistributedLocking;
using Volo.Abp.EventBus.RabbitMq;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.EntityFrameworkCore;

namespace FunShow.Shared.Hosting.Microservices;

[DependsOn(
    typeof(AbpEntityFrameworkCoreModule),
    typeof(FunShowSharedHostingAspNetCoreModule),
    typeof(AbpBackgroundJobsRabbitMqModule),
    typeof(AbpAspNetCoreMultiTenancyModule),
    typeof(AbpDistributedLockingModule),
    typeof(AbpEventBusRabbitMqModule),
    typeof(AbpCachingStackExchangeRedisModule),
    typeof(AdministrationServiceEntityFrameworkCoreModule)
)]
public class FunShowSharedHostingMicroservicesModule: AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        var hostingEnvironment = context.Services.GetHostingEnvironment();

        Configure<AbpMultiTenancyOptions>(options =>
        {
            options.IsEnabled = true;
        });

        Configure<AbpDistributedCacheOptions>(options =>
        {
            options.KeyPrefix = "FunShow:";
        });

        var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);

        context.Services
            .AddDataProtection()
            .SetApplicationName("FunShow")
            .PersistKeysToStackExchangeRedis(redis, "FunShow-Protection-Keys");

        context.Services.AddSingleton<IDistributedLockProvider>(_ =>
            new RedisDistributedSynchronizationProvider(redis.GetDatabase()));
    }
}
