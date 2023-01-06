using Volo.Abp.AuditLogging;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace FunShow.LoggingService;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(AbpAuditLoggingDomainModule),
    typeof(LoggingServiceDomainSharedModule)
)]
public class LoggingServiceDomainModule : AbpModule
{
}
