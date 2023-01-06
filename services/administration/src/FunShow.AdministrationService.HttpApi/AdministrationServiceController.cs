using FunShow.AdministrationService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace FunShow.AdministrationService;

public abstract class AdministrationServiceController : AbpControllerBase
{
    protected AdministrationServiceController()
    {
        LocalizationResource = typeof(AdministrationServiceResource);
    }
}
