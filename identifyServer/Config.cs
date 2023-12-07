using IdentityServer4.Models;

namespace identifyServer
{
    public class Config
    {
        // 下面的scope都是IdentityResource 
        public static IEnumerable<IdentityResource> IdentityResources()
        {
            List<IdentityResource> resources = new List<IdentityResource>();
            //标准的openid和email scope
            resources.Add(new IdentityResources.OpenId());
            resources.Add(new IdentityResources.Profile());
            //自定义的信息
            var employeeInfoScope = new IdentityResource() { 
                    Name = "employee_info",
                    DisplayName = "员工信息",
                    Description = "员工信息",
                    UserClaims = new List<string> { 
                        "employment_start",
                        "seniority",
                        "contractor"
                    }
                };
            return resources;
        }
        // 用户可以用的api资源
        public static IEnumerable<ApiScope> ApiScopes()
        {
            List<ApiScope> scopes = new List<ApiScope>();
            scopes.Add(new ApiScope("api1", "测试api"));
            return scopes;
        }

        public static IEnumerable<ApiResource> ApiResources()
        {
            List<ApiResource> resources = new List<ApiResource>();
            resources.Add(new ApiResource() { Name = "api1", Description = "this is the invoice api", DisplayName = "invoice api service", Scopes = { new string("api1") } });    
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
