// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace SofTrust.Identity
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            { 
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("softrust_report_api", "SofTrust Report API")
            };

        public static IEnumerable<Client> Clients =>
            new Client[] 
            {
                new Client
                {
                    ClientId = "softrust_report_ui",
                    ClientName = "SofTrust Report UI",
                    ClientUri = "http://localhost:3000",

                    AllowedGrantTypes = GrantTypes.Implicit,

                    RequireClientSecret = false,

                    RedirectUris = { "http://localhost:3000/signin-oidc", "http://localhost:3000/silentrenew" },

                    PostLogoutRedirectUris = { "http://localhost:3000/logout/callback" },

                    AllowedCorsOrigins = { "http://localhost:3000" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "softrust_report_api"
                    },

                    AllowAccessTokensViaBrowser = true,

                    AllowOfflineAccess = true
                }
            };
    }
}