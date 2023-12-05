using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddConsole();
    loggingBuilder.AddDebug();
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddIdentityServer()
    .AddInMemoryIdentityResources(identifyServer.Config.IdentityResources())
    .AddInMemoryApiResources(identifyServer.Config.ApiResources())
    .AddInMemoryClients(identifyServer.Config.Clients())
    .AddInMemoryApiScopes(identifyServer.Config.ApiScopes())
    .AddDeveloperSigningCredential();
// �����־


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseIdentityServer();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
