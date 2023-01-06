﻿using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace FunShow.IdentityService;

[DependsOn(
    typeof(IdentityServiceDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class IdentityServiceApplicationContractsModule : AbpModule
{

}
