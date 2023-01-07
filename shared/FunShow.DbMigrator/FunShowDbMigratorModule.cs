using FunShow.AdministrationService;
using FunShow.AdministrationService.EntityFrameworkCore;
using FunShow.IdentityService;
using FunShow.IdentityService.EntityFrameworkCore;
using FunShow.LoggingService;
using FunShow.LoggingService.EntityFrameworkCore;
using FunShow.Shared.Hosting;
using Volo.Abp.Modularity;

namespace FunShow.DbMigrator;

[DependsOn(
    typeof(FunShowSharedHostingModule),
    typeof(IdentityServiceEntityFrameworkCoreModule),
    typeof(IdentityServiceApplicationContractsModule),
    typeof(LoggingServiceEntityFrameworkCoreModule),
    typeof(LoggingServiceApplicationContractsModule),
    typeof(AdministrationServiceEntityFrameworkCoreModule),
    typeof(AdministrationServiceApplicationContractsModule)
)]
public class FunShowDbMigratorModule : AbpModule
{

}
