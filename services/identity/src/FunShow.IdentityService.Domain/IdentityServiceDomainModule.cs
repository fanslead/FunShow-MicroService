using Volo.Abp.Domain;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.OpenIddict;

namespace FunShow.IdentityService;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(IdentityServiceDomainSharedModule),
    typeof(AbpIdentityDomainModule),
    typeof(AbpOpenIddictDomainModule)
)]
public class IdentityServiceDomainModule : AbpModule
{

}
