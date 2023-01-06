using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace FunShow.IdentityService.EntityFrameworkCore;

[ConnectionStringName(IdentityServiceDbProperties.ConnectionStringName)]
public interface IIdentityServiceDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
