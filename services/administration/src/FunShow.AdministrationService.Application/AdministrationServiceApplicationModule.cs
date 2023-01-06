using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.FeatureManagement;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace FunShow.AdministrationService;
[DependsOn(
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AdministrationServiceDomainModule),
    typeof(AdministrationServiceApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
    )]
public class AdministrationServiceApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<AdministrationServiceApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<AdministrationServiceApplicationModule>(validate: true);
        });
    }
}
