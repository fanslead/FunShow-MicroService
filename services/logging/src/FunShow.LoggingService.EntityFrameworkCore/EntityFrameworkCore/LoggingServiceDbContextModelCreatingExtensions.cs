using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace FunShow.LoggingService.EntityFrameworkCore;

public static class LoggingServiceDbContextModelCreatingExtensions
{
    public static void ConfigureLoggingService(this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(LoggingServiceConsts.DbTablePrefix + "YourEntities", LoggingServiceConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
    }
}
