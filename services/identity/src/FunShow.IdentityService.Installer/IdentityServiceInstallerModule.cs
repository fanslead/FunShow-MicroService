using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace FunShow.IdentityService;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class IdentityServiceInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<IdentityServiceInstallerModule>();
        });
    }
}
