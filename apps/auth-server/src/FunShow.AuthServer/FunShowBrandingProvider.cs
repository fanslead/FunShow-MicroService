using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace FunShow.AuthServer;

[Dependency(ReplaceServices = true)]
public class FunShowBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "FunShow";
}
