namespace FunShow.AdministrationService;

public static class AdministrationServiceDbProperties
{
    public static string DbTablePrefix { get; set; } = "";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "AdministrationService";
}
