namespace FunShow.LoggingService;

public static class LoggingServiceDbProperties
{
    public static string DbTablePrefix { get; set; } = "";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "LoggingService";
}
