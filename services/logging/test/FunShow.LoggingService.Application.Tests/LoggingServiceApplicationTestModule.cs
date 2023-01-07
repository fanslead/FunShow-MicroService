using Volo.Abp.Modularity;

namespace FunShow.LoggingService;

[DependsOn(
    typeof(LoggingServiceApplicationModule),
    typeof(LoggingServiceDomainTestModule)
    )]
public class LoggingServiceApplicationTestModule : AbpModule
{

}
