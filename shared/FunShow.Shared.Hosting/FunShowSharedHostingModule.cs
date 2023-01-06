using Volo.Abp.Autofac;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace FunShow.Shared.Hosting;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpDataModule)
)]
public class FunShowSharedHostingModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        // https://www.npgsql.org/efcore/release-notes/6.0.html#opting-out-of-the-new-timestamp-mapping-logic
        System.AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

    }
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureDatabaseConnections();
    }

    private void ConfigureDatabaseConnections()
    {
        Configure<AbpDbConnectionOptions>(options =>
        {

            options.Databases.Configure("AdministrationService", database =>
            {
                database.MappedConnections.Add("AbpAuditLogging");
                database.MappedConnections.Add("AbpPermissionManagement");
                database.MappedConnections.Add("AbpSettingManagement");
                database.MappedConnections.Add("AbpFeatureManagement");
                database.MappedConnections.Add("AbpBlobStoring");
            });

            options.Databases.Configure("IdentityService", database =>
            {
                database.MappedConnections.Add("AbpIdentity");
                database.MappedConnections.Add("OpenIddict");
            });
        });
    }
}
