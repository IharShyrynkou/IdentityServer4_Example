// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Authorization.IdentityServer.Grants
{
    public class GrantsViewModel
    {
        public IEnumerable<IdentityUser> Admins { get; set; }
        public IEnumerable<IdentityUser> Users { get; set; }
    }

    public class GrantViewModel
    {
        public string UserId { get; set; }
        public bool IsActive { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
    }
}