using Volo.Abp.Application;
using Volo.Abp.AuditLogging;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace FunShow.LoggingService;

[DependsOn(
    typeof(LoggingServiceDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class LoggingServiceApplicationContractsModule : AbpModule
{

}
