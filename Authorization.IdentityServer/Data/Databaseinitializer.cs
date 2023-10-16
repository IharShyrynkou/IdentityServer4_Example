using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace Authorization.IdentityServer.Data
{
    public static class DatabaseInitializer
    {
        public static void Init(IServiceProvider scopeServiceProvider)
        {
            var userManager = scopeServiceProvider.GetService<UserManager<IdentityUser>>();

            var users = new List<IdentityUser>()
            {
                new IdentityUser
                {
                    Id = "1",
                    UserName = "Admin",
                    EmailConfirmed = true
                },

                new IdentityUser
                {
                    Id = "2",
                    UserName = "Pasha",
                    EmailConfirmed = false
                },

                new IdentityUser
                {
                    Id = "3",
                    UserName = "Vadim",
                    EmailConfirmed = false
                },

                new IdentityUser
                {
                    Id = "4",
                    UserName = "Valera",
                    EmailConfirmed = false
                },

                new IdentityUser
                {
                    Id = "5",
                    UserName = "Dima",
                    EmailConfirmed = false
                },

            };

            foreach (var user in users)
            {
                var result = userManager.CreateAsync(user, "123qwe").GetAwaiter().GetResult();
                if (result.Succeeded)
                {
                    userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "User")).GetAwaiter().GetResult();
                    userManager.AddClaimAsync(user, new Claim(JwtClaimTypes.EmailVerified, user.EmailConfirmed.ToString())).GetAwaiter().GetResult();
                }
            }

            userManager.AddClaimAsync(users.First(), new Claim(ClaimTypes.Role, "Administrator")).GetAwaiter().GetResult();

        }
    }
}