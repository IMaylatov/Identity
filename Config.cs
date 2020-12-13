using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace SofTrust.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource("roles", new[] { "role" })
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("softrust_report_api", "SofTrust Report API", new List<string>() { "role" }),
                new ApiScope("softrust_account_api", "SofTrust Account API", new List<string>() { "role" })
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
                        JwtClaimTypes.Role,
                        "softrust_report_api"
                    },

                    AllowAccessTokensViaBrowser = true,

                    AllowOfflineAccess = true
                },
                new Client
                {
                    ClientId = "softrust_account_ui",
                    ClientName = "SofTrust Account UI",
                    ClientUri = "http://localhost:3001",

                    AllowedGrantTypes = GrantTypes.Implicit,

                    RequireClientSecret = false,

                    RedirectUris = { "http://localhost:3001/signin-oidc", "http://localhost:3001/silentrenew" },

                    PostLogoutRedirectUris = { "http://localhost:3001/logout/callback" },

                    AllowedCorsOrigins = { "http://localhost:3001" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        JwtClaimTypes.Role,
                        "softrust_account_api"
                    },

                    AllowAccessTokensViaBrowser = true,

                    AllowOfflineAccess = true
                }
            };
    }
}