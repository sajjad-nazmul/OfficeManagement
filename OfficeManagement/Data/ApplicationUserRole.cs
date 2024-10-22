using Microsoft.AspNetCore.Identity;

namespace OfficeManagement.Data
{
    public class ApplicationUserRole : IdentityRole
    {
        public int Preference { get; set; }
    }
}
