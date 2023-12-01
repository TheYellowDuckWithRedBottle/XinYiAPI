using IdentityServer4.Models;

namespace identifyServer
{
    public class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources()
        {
            List<IdentityResource> resources = new List<IdentityResource>();
            resources.Add(new IdentityResources.OpenId());
            resources.Add(new IdentityResources.Profile());
            return resources;
        }

        public static IEnumerable<ApiResource> ApiResources()
        {
            List<ApiResource> resources = new List<ApiResource>();
            resources.Add(new ApiResource("api/District/GetDistricts", "测试api"));
            return resources;
        }
        public static IEnumerable<Client> Clients()
        {
            List<Client> clients = new List<Client>();
            clients.Add(new Client
            {
                ClientId = "fanyutan",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret("fanyutan123456".Sha256())
                },
                AllowedScopes = { "api/District/GetDistricts" }
            });
            return clients;
        }
    }
}
