using Volo.Abp.Modularity;

namespace FunShow.IdentityService;

[DependsOn(
    typeof(IdentityServiceApplicationModule),
    typeof(IdentityServiceDomainTestModule)
    )]
public class IdentityServiceApplicationTestModule : AbpModule
{

}
