using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Airport.Authorization
{
    public class BannedFromLoungeHandler : AuthorizationHandler<AllowedInLoungeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AllowedInLoungeRequirement requirement)
        {
            var isBanned = context.User.HasClaim(c => c.Type == Claims.IsBannedFromLounge);

            if (isBanned)
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}