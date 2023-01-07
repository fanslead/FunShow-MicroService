using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;
using Volo.Abp.Identity;

namespace FunShow.IdentityService;

[DependsOn(
    typeof(IdentityServiceDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpIdentityApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class IdentityServiceApplicationContractsModule : AbpModule
{

}
