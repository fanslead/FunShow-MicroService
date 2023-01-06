using FunShow.AdministrationService.Localization;
using Volo.Abp.Application.Services;

namespace FunShow.AdministrationService;

public abstract class AdministrationServiceAppService : ApplicationService
{
    protected AdministrationServiceAppService()
    {
        LocalizationResource = typeof(AdministrationServiceResource);
        ObjectMapperContext = typeof(AdministrationServiceApplicationModule);
    }
}
