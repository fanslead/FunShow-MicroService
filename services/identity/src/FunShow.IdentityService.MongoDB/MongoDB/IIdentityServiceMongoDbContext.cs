using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace FunShow.IdentityService.MongoDB;

[ConnectionStringName(IdentityServiceDbProperties.ConnectionStringName)]
public interface IIdentityServiceMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
