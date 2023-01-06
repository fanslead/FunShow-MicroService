using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace FunShow.IdentityService;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(IdentityServiceDomainSharedModule)
)]
public class IdentityServiceDomainModule : AbpModule
{

}
