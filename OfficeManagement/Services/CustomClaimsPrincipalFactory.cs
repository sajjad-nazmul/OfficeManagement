using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using OfficeManagement.Data;
using System.Security.Claims;

namespace OfficeManagement.Services
{
    public class CustomClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, ApplicationUserRole>
    {
        public CustomClaimsPrincipalFactory(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationUserRole> roleManager,
            IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, roleManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);

            var roles = await UserManager.GetRolesAsync(user);
            var roleEntities = new List<ApplicationUserRole>();
            foreach (var roleName in roles)
            {
                var role = await RoleManager.FindByNameAsync(roleName);
                if (role != null)
                {
                    roleEntities.Add(role);
                }
            }

            // Get the highest preference role
            var highestPreferenceRole = roleEntities
                .OrderByDescending(role => role.Preference)
                .FirstOrDefault();

            if (highestPreferenceRole != null)
            {
                var roleClaim = new Claim("HighestRole", highestPreferenceRole.Name ?? "User");
                identity.AddClaim(roleClaim);
            }

            return identity;
        }
    }
}
