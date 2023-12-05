// See https://aka.ms/new-console-template for more information
using IdentityModel.Client;

Console.WriteLine("Hello, World!");
var client = new HttpClient();
var disco = await client.GetDiscoveryDocumentAsync("http://localhost:3000");
if (disco.IsError)
{
    Console.WriteLine(disco.Error);
    return;
}

var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
{
    Address = disco.TokenEndpoint,
    ClientId = "testUser",
    ClientSecret = "testUser123456",
    Scope = "api1"
});

if (tokenResponse.IsError)
{
    Console.WriteLine(tokenResponse.Error);
    return;
}

Console.WriteLine(tokenResponse.Json);