using FunShow.AdministrationService.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using Volo.Abp.DistributedLocking;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;
using FunShow.Shared.Hosting.Microservices.DbMigrations.EfCore;
using Volo.Abp.Domain.Entities.Events.Distributed;

namespace FunShow.AdministrationService.DbMigrations
{
    public class AdministrationServiceDatabaseMigrationChecker : PendingEfCoreMigrationsChecker<AdministrationServiceDbContext>
    {
        public AdministrationServiceDatabaseMigrationChecker(
            ILoggerFactory loggerFactory,
            IUnitOfWorkManager unitOfWorkManager,
            IServiceProvider serviceProvider,
            ICurrentTenant currentTenant,
            IDistributedEventBus distributedEventBus,
            IAbpDistributedLock abpDistributedLock)
            : base(
                loggerFactory,
                unitOfWorkManager,
                serviceProvider,
                currentTenant,
                distributedEventBus,
                abpDistributedLock,
                AdministrationServiceDbProperties.ConnectionStringName)
        {
        }
    }

}
