using Volo.Abp;
using Volo.Abp.MongoDB;

namespace FunShow.IdentityService.MongoDB;

public static class IdentityServiceMongoDbContextExtensions
{
    public static void ConfigureIdentityService(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
