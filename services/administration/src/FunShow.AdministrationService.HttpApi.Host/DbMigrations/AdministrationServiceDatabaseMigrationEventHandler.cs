using FunShow.AdministrationService.EntityFrameworkCore;
using FunShow.Shared.Hosting.Microservices.DbMigrations;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using Volo.Abp.Data;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.TenantManagement;

namespace FunShow.AdministrationService.DbMigrations
{
    public class AdministrationServiceDatabaseMigrationEventHandler
    : DatabaseMigrationEventHandlerBase<AdministrationServiceDbContext>,
        IDistributedEventHandler<TenantCreatedEto>,
        IDistributedEventHandler<TenantConnectionStringUpdatedEto>,
        IDistributedEventHandler<ApplyDatabaseMigrationsEto>
    {
        public AdministrationServiceDatabaseMigrationEventHandler(
            ILoggerFactory loggerFactory,
            ICurrentTenant currentTenant,
            IUnitOfWorkManager unitOfWorkManager,
            ITenantStore tenantStore,
            ITenantRepository tenantRepository,
            IDistributedEventBus distributedEventBus
        ) : base(
            loggerFactory,
            currentTenant,
            unitOfWorkManager,
            tenantStore,
            tenantRepository,
            distributedEventBus,
            AdministrationServiceDbProperties.ConnectionStringName)
        {

        }

        public async Task HandleEventAsync(ApplyDatabaseMigrationsEto eventData)
        {
            if (eventData.DatabaseName != DatabaseName)
            {
                return;
            }

            try
            {
                var schemaMigrated = await MigrateDatabaseSchemaAsync(eventData.TenantId);

                if (eventData.TenantId == null && schemaMigrated)
                {
                    /* Migrate tenant databases after host migration */
                    await QueueTenantMigrationsAsync();
                }
            }
            catch (Exception ex)
            {
                await HandleErrorOnApplyDatabaseMigrationAsync(eventData, ex);
            }
        }

        public async Task HandleEventAsync(TenantCreatedEto eventData)
        {
            try
            {
                await MigrateDatabaseSchemaAsync(eventData.Id);
            }
            catch (Exception ex)
            {
                await HandleErrorTenantCreatedAsync(eventData, ex);
            }
        }

        public async Task HandleEventAsync(TenantConnectionStringUpdatedEto eventData)
        {
            if (eventData.ConnectionStringName != DatabaseName && eventData.ConnectionStringName != ConnectionStrings.DefaultConnectionStringName ||
                eventData.NewValue.IsNullOrWhiteSpace())
            {
                return;
            }

            try
            {
                await MigrateDatabaseSchemaAsync(eventData.Id);

                /* You may want to move your data from the old database to the new database!
                * It is up to you. If you don't make it, new database will be empty. */
            }
            catch (Exception ex)
            {
                await HandleErrorTenantConnectionStringUpdatedAsync(eventData, ex);
            }
        }
    }

}
