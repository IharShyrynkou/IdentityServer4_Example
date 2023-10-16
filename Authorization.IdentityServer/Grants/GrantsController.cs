// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Events;
using IdentityServer4.Extensions;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Authorization.IdentityServer.Grants
{
    /// <summary>
    /// This sample controller allows a user to revoke grants given to clients
    /// </summary>
    [SecurityHeaders]
    [Authorize]
    public class GrantsController : Controller
    {
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IClientStore _clients;
        private readonly IResourceStore _resources;
        private readonly IEventService _events;
        private readonly UserManager<IdentityUser> _userManager;

        public GrantsController(IIdentityServerInteractionService interaction,
            IClientStore clients,
            IResourceStore resources,
            IEventService events, UserManager<IdentityUser> userManager)
        {
            _interaction = interaction;
            _clients = clients;
            _resources = resources;
            _events = events;
            _userManager = userManager;
        }

        /// <summary>
        /// Show list of grants
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View("Index", await BuildViewModelAsync());
        }

        /// <summary>
        /// Handle postback to revoke a client
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Revoke(string clientId)
        {
            var user = _userManager.Users.First(u => u.Id == clientId);

            if (user.EmailConfirmed)
            {
                await _userManager.ReplaceClaimAsync(
                    user, 
                    new Claim(JwtClaimTypes.EmailVerified, "true"), 
                    new Claim(JwtClaimTypes.EmailVerified, "false"));
                user.EmailConfirmed = false;

                //await _userManager.RemoveFromRoleAsync(user, "Administrator");
                //await _userManager.AddToRoleAsync(user, "User");
            }

            else
            {
                await _userManager.ReplaceClaimAsync(
                    user, 
                    new Claim(JwtClaimTypes.EmailVerified, "false"), 
                    new Claim(JwtClaimTypes.EmailVerified, "true"));
                user.EmailConfirmed = true;

                //await _userManager.RemoveFromRoleAsync(user, "User");
                //await _userManager.AddToRoleAsync(user, "Administrator");
            }



            user = _userManager.Users.First(u => u.Id == clientId);



            _userManager.UpdateAsync(user);
            return RedirectToAction("Index");
        }

        private async Task<GrantsViewModel> BuildViewModelAsync()
        {
            var admins = await _userManager.GetUsersForClaimAsync(new Claim(ClaimTypes.Role, "Administrator"));
            var users = await _userManager.GetUsersForClaimAsync(new Claim(ClaimTypes.Role, "User"));

            //var list = new List<GrantViewModel>();
            //var list = new List<GrantViewModel>();

            //foreach (var user in admins)
            //{
            //        var item = new GrantViewModel()
            //        {
            //            UserId = user.Id,
            //            IsActive = true,
            //            UserName = user.UserName,
            //            Role = "Administrator"
            //        };

            //        list.Add(item);
            //}

            //foreach (var user in users)
            //{
            //    var item = new GrantViewModel()
            //    {
            //        UserId = user.Id,
            //        IsActive = true,
            //        UserName = user.UserName,
            //        Role = "User"
            //    };

            //    list.Add(item);
            //}

            return new GrantsViewModel
            {
                Users = users,
                Admins = admins
            };
        }
    }
}