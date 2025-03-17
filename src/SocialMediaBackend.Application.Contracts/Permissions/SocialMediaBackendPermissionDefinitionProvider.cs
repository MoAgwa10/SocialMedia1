using SocialMediaBackend.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace SocialMediaBackend.Permissions;

public class SocialMediaBackendPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(SocialMediaBackendPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(SocialMediaBackendPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SocialMediaBackendResource>(name);
    }
}
