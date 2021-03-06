using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Fleetmanagement.IdentityProvider
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            { 
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()               
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope { Name = "fleetmanagement-read-api" },
                new ApiScope { Name = "fleetmanagement-write-api" } 
            };

        public static IEnumerable<Client> Clients =>
            new Client[] 
            {
                new Client
                { 
                    ClientId = "fleetmanagement-driver-webgui",
                    ClientName = "Fleetmanagement Driver WebGUI",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RedirectUris = { "http://localhost:3000/callback" },
                    PostLogoutRedirectUris = { "http://localhost:3000" },
                    AllowedCorsOrigins = { "https://localhost:3000", "http://localhost:3000" },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "fleetmanagement-read-api",
                        "fleetmanagement-write-api"
                    },
                    ClientSecrets =
                    {
                        new Secret("1523948B-FBBE-4D49-B164-6DF098DD1100".Sha256())
                
                    }
                }
            };
    }
}