using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace FunShow.Shared.Hosting.AspNetCore
{
    public static class ApolloConfigurationExtension
    {
        public static IHostBuilder UseApollo(this IHostBuilder builder)
        {
            return builder
                .ConfigureAppConfiguration((config) =>
                {
                    config.AddApollo(config.Build().GetSection("apollo"));
                });
        }
    }
}