using System.Security.Claims;

using static TankCleaningProject.Areas.Admin.AdminConstants;

namespace TankCleaningProject.Infrastructure
{
    public static class ClaimExtension
    {
        public static string Id(this ClaimsPrincipal user)
            => user.FindFirst(ClaimTypes.NameIdentifier).Value;

        public static bool IsAdmin(this ClaimsPrincipal user)
            => user.IsInRole(AdministratorRoleName);
    }
}

