using FunShow.LoggingService.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace FunShow.LoggingService;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(LoggingServiceEntityFrameworkCoreTestModule)
    )]
public class LoggingServiceDomainTestModule : AbpModule
{

}
