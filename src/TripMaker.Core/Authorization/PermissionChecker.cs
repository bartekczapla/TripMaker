using Abp.Authorization;
using TripMaker.Authorization.Roles;
using TripMaker.Authorization.Users;

namespace TripMaker.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
