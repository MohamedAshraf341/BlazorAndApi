using System;
using System.Collections.Generic;

namespace Common.Helpers
{
    public class Permissions
    {
        public static List<string> GeneratePermissionsList(string module)
        {
            return new List<string>()
            {
                $"Permissions.{module}.View",
                $"Permissions.{module}.Create",
                $"Permissions.{module}.Edit",
                $"Permissions.{module}.Delete"
            };
        }
        public static List<string> GenerateAllPermissions()
        {
            var allPermissions = new List<string>();

            var modules = Enum.GetValues(typeof(Modules));

            foreach (var module in modules)
                allPermissions.AddRange(GeneratePermissionsList(module.ToString()));

            return allPermissions;
        }
        public static class AuthorModule
        {
            public const string View = "Permissions.Author.View";
            public const string Create = "Permissions.Author.Create";
            public const string Edit = "Permissions.Author.Edit";
            public const string Delete = "Permissions.Author.Delete";
        }
    }
}
