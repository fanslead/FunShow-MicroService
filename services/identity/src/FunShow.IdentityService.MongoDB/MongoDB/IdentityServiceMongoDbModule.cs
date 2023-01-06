using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace FunShow.IdentityService.MongoDB;

[DependsOn(
    typeof(IdentityServiceDomainModule),
    typeof(AbpMongoDbModule)
    )]
public class IdentityServiceMongoDbModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddMongoDbContext<IdentityServiceMongoDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, MongoQuestionRepository>();
                 */
        });
    }
}
