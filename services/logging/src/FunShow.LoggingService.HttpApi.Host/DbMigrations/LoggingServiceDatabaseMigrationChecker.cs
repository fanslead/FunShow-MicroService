using System;
using Microsoft.Extensions.Logging;
using FunShow.LoggingService.EntityFrameworkCore;
using FunShow.Shared.Hosting.Microservices.DbMigrations.EfCore;
using Volo.Abp.DistributedLocking;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace FunShow.LoggingService.DbMigrations;

public class LoggingServiceDatabaseMigrationChecker : PendingEfCoreMigrationsChecker<LoggingServiceDbContext>
{
    public LoggingServiceDatabaseMigrationChecker(
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
            LoggingServiceDbProperties.ConnectionStringName)
    {

    }
}
