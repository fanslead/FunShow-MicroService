using Volo.Abp.Modularity;

namespace Walk.LoggingService;

[DependsOn(
    typeof(LoggingServiceApplicationModule),
    typeof(LoggingServiceDomainTestModule)
    )]
public class LoggingServiceApplicationTestModule : AbpModule
{

}
