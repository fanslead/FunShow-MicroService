using FunShow.LoggingService.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace FunShow.LoggingService.Permissions;

public class LoggingServicePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(LoggingServicePermissions.GroupName, L("Permission:LoggingService"));

        var auditLogging = myGroup.AddPermission(LoggingServicePermissions.AuditLogging.Default, L("AuditLogging"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(BookStorePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<LoggingServiceResource>(name);
    }
}
