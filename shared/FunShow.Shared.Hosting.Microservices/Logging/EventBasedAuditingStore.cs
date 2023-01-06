using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Volo.Abp.Auditing;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Uow;

namespace FunShow.Shared.Hosting.Microservices.Logging
{
    [Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(IAuditingStore))]
    public class EventBasedAuditingStore : IAuditingStore, ITransientDependency
    {
        private readonly IDistributedEventBus _distributedEventBus;
        private readonly ILogger<EventBasedAuditingStore> _logger;

        public EventBasedAuditingStore(IDistributedEventBus distributedEventBus, ILogger<EventBasedAuditingStore> logger)
        {
            _distributedEventBus = distributedEventBus;
            _logger = logger;
        }

        [UnitOfWork]
        public async Task SaveAsync(AuditLogInfo auditInfo)
        {
            _logger.LogInformation("Publishing audit log creation...");

            // EntityEntry will break serialization so we remove it
            for (var i = 0; i < auditInfo.EntityChanges.Count; i++)
            {
                auditInfo.EntityChanges[i].EntityEntry = null;
            }
            
            await _distributedEventBus.PublishAsync(auditInfo);
        }
    }
}