using System;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;

namespace FunShow.Shared.Hosting.AspNetCore;

[DependsOn(
    typeof(FunShowSharedHostingModule),
    typeof(AbpAspNetCoreSerilogModule),
    typeof(AbpSwashbuckleModule)
)]
public class FunShowSharedHostingAspNetCoreModule : AbpModule
{

}
