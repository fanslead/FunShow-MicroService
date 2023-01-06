using Volo.Abp.Reflection;

namespace FunShow.LoggingService.Permissions;

public class LoggingServicePermissions
{
    public const string GroupName = "LoggingService";
    public static class AuditLogging
    {
        public const string Default = GroupName + ".AuditLogging";
    }
    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(LoggingServicePermissions));
    }
}
