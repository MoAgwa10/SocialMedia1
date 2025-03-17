using System;

namespace SocialMediaBackend.Permissions;

public static class SocialMediaBackendPermissions
{
    public const string GroupName = "SocialMediaBackend";

   

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";
    public static class List
    {
        public const string Default = GroupName + ".List";
        public const string Create = GroupName + ".List.Create";
        public const string Edit = GroupName + ".List.Edit";
        public const string Delete = GroupName + ".List.Delete";
    }
}
