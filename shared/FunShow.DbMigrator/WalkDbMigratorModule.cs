using FunShow.AdministrationService;
using FunShow.AdministrationService.EntityFrameworkCore;
using FunShow.IdentityService;
using FunShow.IdentityService.EntityFrameworkCore;
using FunShow.ProductService;
using FunShow.ProductService.EntityFrameworkCore;
using FunShow.SaasService;
using FunShow.SaasService.EntityFrameworkCore;
using FunShow.Shared.Hosting;
using Volo.Abp.Modularity;

namespace FunShow.DbMigrator;

[DependsOn(
    typeof(FunShowSharedHostingModule),
    typeof(IdentityServiceEntityFrameworkCoreModule),
    typeof(IdentityServiceApplicationContractsModule),
    typeof(SaasServiceEntityFrameworkCoreModule),
    typeof(SaasServiceApplicationContractsModule),
    typeof(AdministrationServiceEntityFrameworkCoreModule),
    typeof(AdministrationServiceApplicationContractsModule),
    typeof(ProductServiceApplicationContractsModule),
    typeof(ProductServiceEntityFrameworkCoreModule)
)]
public class FunShowDbMigratorModule : AbpModule
{

}
