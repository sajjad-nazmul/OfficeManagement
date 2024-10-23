namespace OfficeManagement.Helpers
{
    public static class Constants
    {
        public static readonly Dictionary<string, string> RoleDashboardMap = new Dictionary<string, string>
            {
                { "Admin", "/Dashboard/AdminDashboard" },
                { "Moderator", "/Dashboard/ModeratorDashboard" },
                { "User", "/Dashboard/UserDashboard" },
                { "Super User", "/Dashboard/SuperUserDashboard" }
            };

        public static readonly Dictionary<string, string> RoleProfileMap = new Dictionary<string, string>
            {
                { "Admin", "/Profile/Admin" },
                { "Moderator", "/Profile/Moderator" },
                { "User", "/Profile/User" },
                { "Super User", "/Profile/SuperUser" }
            };
    }
}
