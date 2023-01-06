using FunShow.IdentityService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace FunShow.IdentityService;

public abstract class IdentityServiceController : AbpControllerBase
{
    protected IdentityServiceController()
    {
        LocalizationResource = typeof(IdentityServiceResource);
    }
}
