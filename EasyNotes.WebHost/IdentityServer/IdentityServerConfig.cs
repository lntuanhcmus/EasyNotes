using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNotes.WebHost.IdentityServer
{
    public class IdentityServerConfig
    {

        public static IEnumerable<IdentityResource> Ids => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };

        public static IEnumerable<ApiResource> Apis => new ApiResource[]
        {
            new ApiResource("api.net.beyondedge","NET API")
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
{
            new ApiScope("api.net.beyondedge","NET API")
};
        public static IEnumerable<Client> Clients => new Client[]
        {
            new Client
            {
                ClientId = "mvc",
                ClientSecrets = {new Secret("secret".Sha256())},

                AllowedGrantTypes = GrantTypes.Code,
                RequireConsent = false,
                RequirePkce = true,
                AllowOfflineAccess = true,
                AllowedCorsOrigins={"http://localhost/"},

                RedirectUris = {"https://localhost:44308/signin-oidc"},

                PostLogoutRedirectUris = { "https://localhost:44308/signout-callback-oidc" },

                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.OfflineAccess,
                    "api.net.beyondedge"
                }
            }
        };
    }
}
