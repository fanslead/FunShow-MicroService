using System;
using System.Globalization;
using FunShow.Shared.Hosting.AspNetCore.JsonConverters;
using Microsoft.AspNetCore.Builder;
using Volo.Abp;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Json.SystemTextJson;
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

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpSystemTextJsonSerializerOptions>(options => options.JsonSerializerOptions.Converters.Add(new ExceptionJsonConverter<Exception>()));
    }
    public override void OnApplicationInitialization(Volo.Abp.ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
    }
}
