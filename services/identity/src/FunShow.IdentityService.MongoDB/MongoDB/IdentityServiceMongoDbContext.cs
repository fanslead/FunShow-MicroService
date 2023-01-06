using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace FunShow.IdentityService.MongoDB;

[ConnectionStringName(IdentityServiceDbProperties.ConnectionStringName)]
public class IdentityServiceMongoDbContext : AbpMongoDbContext, IIdentityServiceMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureIdentityService();
    }
}
