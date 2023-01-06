using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Volo.Abp.Auditing;
using Volo.Abp.AuditLogging;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Uow;

namespace FunShow.LoggingService.HttpApi.Host.Handlers
{
    public class AuditCreationHandler : IDistributedEventHandler<AuditLogInfo>, ITransientDependency
    {
        private readonly IAuditLogRepository _auditLogRepository;
        private readonly IAuditLogInfoToAuditLogConverter _converter;
        private readonly ILogger<AuditCreationHandler> _logger;

        public AuditCreationHandler(IAuditLogRepository auditLogRepository, IAuditLogInfoToAuditLogConverter converter,
            ILogger<AuditCreationHandler> logger)
        {
            _converter = converter;
            _logger = logger;
            _auditLogRepository = auditLogRepository;
        }

        [UnitOfWork]
        public async Task HandleEventAsync(AuditLogInfo eventData)
        {
            try
            {
                _logger.LogInformation("Handling Audit Creation...");
                await _auditLogRepository.InsertAsync(await _converter.ConvertAsync(eventData));
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Could not save the audit log object ...");
                _logger.LogException(ex, LogLevel.Error);
            }
        }
    }
}