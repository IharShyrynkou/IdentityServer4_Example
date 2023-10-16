using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;

namespace Authorization.IdentityServer.Infrastructure
{
    public class ProfileService : IProfileService
    {
        protected UserManager<IdentityUser> _userManager;

        public ProfileService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        //здесь добавляются клеймы claims
        /// <summary>
        /// This method is called whenever claims about the user are requested (e.g. during token creation or via the userinfo endpoint)
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {

            var user = await _userManager.GetUserAsync(context.Subject);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.DateOfBirth, "01.01.2010"),
                new Claim(JwtClaimTypes.EmailVerified, user.EmailConfirmed.ToString()),
                new Claim(JwtClaimTypes.Name, user.UserName.ToString()),
            };

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(JwtClaimTypes.Role, role));
            }

            
            context.IssuedClaims.AddRange(claims);
        }

        /// <summary>
        /// This method gets called whenever identity server needs to determine if the user is valid or active (e.g. if the user's account has been deactivated since they logged in).
        /// (e.g. during token issuance or validation).
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public async Task IsActiveAsync(IsActiveContext context)
        {
            var user = await _userManager.GetUserAsync(context.Subject);

            context.IsActive = true;
        }
    }
}
