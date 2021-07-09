using IdentityServer4.Models;
using System.Collections.Generic;

namespace Fleetmanagement.Identity
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            { 
                new IdentityResources.OpenId()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("read-api", "Fleetmanagement read API"),
                new ApiScope("write-api", "Fleetmanagement write API")
            };

        public static IEnumerable<Client> Clients =>
            new Client[] 
            {
                new Client 
                { 
                    ClientId = "driver-webgui",
                    ClientSecrets = { new Secret("zanyPan)a35".Sha512()) },
                    AllowedScopes = { "read-api", "write-api" }
                }
            };
    }
}