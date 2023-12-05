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
        public static IEnumerable<ApiScope> ApiScopes()
        {
            List<ApiScope> scopes = new List<ApiScope>();
            scopes.Add(new ApiScope("api1", "测试api"));
            return scopes;
        }

        public static IEnumerable<ApiResource> ApiResources()
        {
            List<ApiResource> resources = new List<ApiResource>();
            resources.Add(new ApiResource("api1", "测试api"));
            return resources;
        }
        public static IEnumerable<Client> Clients()
        {
            List<Client> clients = new List<Client>();
            clients.Add(new Client
            {
                ClientId = "testUser",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret("testUser123456".Sha256())
                },
                AllowedScopes = { "api1" }
            });
            return clients;
        }
    }
}
