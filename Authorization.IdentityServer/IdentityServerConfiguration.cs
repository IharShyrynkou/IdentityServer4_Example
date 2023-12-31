﻿using System.Collections.Generic;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace Authorization.IdentityServer
{
    public static class IdentityServerConfiguration
    {
        public static IEnumerable<Client> GetClients() =>
        new List<Client>
        {
            new Client
            {
                ClientId = "client_blazor_web_assembly",
                RequireClientSecret = false,
                RequireConsent = false,
                RequirePkce = true,
                AllowedGrantTypes =  GrantTypes.Code,
                AllowedCorsOrigins = { "http://localhost:8001" },
                PostLogoutRedirectUris = { "http://localhost:8001" },
                RedirectUris = { "http://localhost:8001/authentication/login-callback" },
                AllowedScopes =
                {
                    "blazor",
                    "OrdersAPI",
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                }
            },

            new Client
            {
                ClientId = "client_test",
                RequireClientSecret = false,
                RequireConsent = false,
                RequirePkce = true,
                AllowedGrantTypes =  GrantTypes.Code,
                AllowedCorsOrigins = { "http://localhost:9001" },
                PostLogoutRedirectUris = { "http://localhost:9001" },
                RedirectUris = { "http://localhost:9001/authentication/login-callback" },
                RefreshTokenExpiration = TokenExpiration.Absolute,
                RefreshTokenUsage = TokenUsage.ReUse,
                AccessTokenType = AccessTokenType.Jwt,
                UpdateAccessTokenClaimsOnRefresh = true,
                AllowedScopes =
                {
                    "blazor",
                    "OrdersAPI",
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                }
            },

            new Client
            {
                ClientId = "client_id_js",
                RequireClientSecret = false,
                RequireConsent = false,
                RequirePkce = true,
                AllowedGrantTypes =  GrantTypes.Code,
                AllowedCorsOrigins = { "http://localhost:9001" },
                RedirectUris = { "http://localhost:9001", "http://localhost:9001/refresh.html" },
                PostLogoutRedirectUris = { "http://localhost:9001/index.html" },
                AccessTokenLifetime = 5,
                
                AllowOfflineAccess = true,
                AllowedScopes =
                {
                    "OrdersAPI",
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                }
            },
            new Client
            {
                ClientId = "client_id_swagger",
                ClientSecrets = { new Secret("client_secret_swagger".ToSha256()) },
                AllowedGrantTypes =  GrantTypes.ResourceOwnerPassword,
                AllowedCorsOrigins = { "http://localhost:7001" },
                AllowedScopes =
                {
                    "SwaggerAPI",
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                }
            },
            new Client
            {
                ClientId = "client_id",
                ClientSecrets = { new Secret("client_secret".ToSha256()) },
                
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes =
                {
                    "OrdersAPI",
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                }
            },
            new Client
            {
                ClientId = "client_id_mvc",
                ClientSecrets = { new Secret("client_secret_mvc".ToSha256()) },

                AllowedGrantTypes = GrantTypes.Code,

                AllowedScopes =
                {
                    "OrdersAPI",
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                },

                RedirectUris = {"http://localhost:2001/signin-oidc"},
                PostLogoutRedirectUris = {"http://localhost:2001/signout-callback-oidc"},

                RequireConsent = false,

                AccessTokenLifetime = 5,

                AllowOfflineAccess = true
            }
        };

      
        public static IEnumerable<ApiResource> GetApiResources()
        {
            yield return new ApiResource("SwaggerAPI");
            yield return new ApiResource("OrdersAPI");
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            yield return new IdentityResources.OpenId();
            yield return new IdentityResources.Profile();
        }

        /// <summary>
        /// IdentityServer4 version 4.x.x changes
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ApiScope> GetApiScopes()
        {
            yield return new ApiScope("SwaggerAPI", "Swagger API");
            yield return new ApiScope("blazor", "Blazor WebAssembly");
            yield return new ApiScope("OrdersAPI", "Orders API");
        }
    }
}
