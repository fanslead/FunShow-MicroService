using FunShow.IdentityService.Localization;
using Volo.Abp.Application.Services;

namespace FunShow.IdentityService;

public abstract class IdentityServiceAppService : ApplicationService
{
    protected IdentityServiceAppService()
    {
        LocalizationResource = typeof(IdentityServiceResource);
        ObjectMapperContext = typeof(IdentityServiceApplicationModule);
    }
}
