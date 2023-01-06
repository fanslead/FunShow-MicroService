using FunShow.LoggingService.Localization;
using Volo.Abp.Application.Services;

namespace FunShow.LoggingService;

public abstract class LoggingServiceAppService : ApplicationService
{
    protected LoggingServiceAppService()
    {
        LocalizationResource = typeof(LoggingServiceResource);
        ObjectMapperContext = typeof(LoggingServiceApplicationModule);
    }
}
