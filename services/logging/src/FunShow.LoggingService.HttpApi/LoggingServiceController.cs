using FunShow.LoggingService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace FunShow.LoggingService;

public abstract class LoggingServiceController : AbpControllerBase
{
    protected LoggingServiceController()
    {
        LocalizationResource = typeof(LoggingServiceResource);
    }
}
