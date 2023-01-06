using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.PermissionManagement;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.Domain.Repositories;

namespace FunShow.AdministrationService.EntityFrameworkCore;

[ConnectionStringName(AdministrationServiceDbProperties.ConnectionStringName)]
public class AdministrationServiceDbContext : AbpDbContext<AdministrationServiceDbContext>, IAdministrationServiceDbContext,
    IPermissionManagementDbContext,
    ISettingManagementDbContext,
    IFeatureManagementDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public AdministrationServiceDbContext(DbContextOptions<AdministrationServiceDbContext> options)
        : base(options)
    {

    }

    public DbSet<PermissionGroupDefinitionRecord> PermissionGroups { get; set; }

    public DbSet<PermissionDefinitionRecord> Permissions { get; set; }

    public DbSet<PermissionGrant> PermissionGrants { get; set; }

    public DbSet<FeatureGroupDefinitionRecord> FeatureGroups { get; set; }

    public DbSet<FeatureDefinitionRecord> Features { get; set; }

    public DbSet<FeatureValue> FeatureValues { get; set; }

    public DbSet<Setting> Settings { get; set; }

    public DbSet<Tenant> Tenants { get; set; }

    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    protected IRepository<Tenant> TenantRepository { get; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureAdministrationService();
        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();
    }
}
