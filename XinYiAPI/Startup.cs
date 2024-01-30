using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using XinYiAPI.Services;
using XinYiAPI.DataAccess.Base;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using XinYiAPI.Common;
using Microsoft.OpenApi.Models;

namespace XinYiAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }
        public string ApiName { get; set; } = "XINYI.API";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var secretKey = Configuration["JwtSetting:SecretKey"];
            var issuer = Configuration["JwtSetting:Issuer"];
            var aduient = Configuration["JwtSetting:Audience"];
            var key = Encoding.UTF8.GetBytes(secretKey);
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Client", policy => policy.RequireRole("Client").Build());//单独角色
                options.AddPolicy("Admin", policy => policy.RequireRole("Admin").Build());
                //options.AddPolicy("SystemOrAdmin", policy => policy.RequireRole("Admin", "System"));//或的关系
                      
            });
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    // 是否验证颁发者
                    ValidateIssuer = true,
                    // 是否验证访问群体
                    ValidateAudience = true,
                    // 是否验证生命周期
                    ValidateLifetime = true,
                    // 是否验证安全密钥
                    ValidateIssuerSigningKey = true,
                    // 访问群体
                    ValidAudience = aduient,
                    // 颁发者
                    ValidIssuer = issuer,
                    // 安全密钥
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });
           
            services.AddSingleton(new JwtService(secretKey, issuer, aduient));
            services.AddControllers();
            services.AddDbContext<AlanContext>(options =>
                            options.UseMySql(Configuration.GetConnectionString("DefaultConnection"),
                            options => options.EnableRetryOnFailure()));
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins, policy =>
                {
                    policy.AllowAnyHeader()
                    .AllowAnyOrigin()
                    .WithMethods("GET", "POST", "HEAD", "PUT", "DELETE", "OPTIONS");
                });
            });
            services.AddScoped<LandSpaceService>();
            services.AddScoped<SecCateService>();
            services.AddScoped<ProvinceService>();
            services.AddScoped<CityService>();
            services.AddScoped<DistrictService>();
            services.AddScoped<MapTemplateService>();
            services.AddControllers().AddNewtonsoftJson(options => options.UseMemberCasing());
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = $"{ApiName}",
                    Version = "v1",
                    Description = $"{ApiName}接口文档-Netcore 3.1",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "LeviFan",
                        Email = "1521681359@qq.com"
                    }
                });
                options.OrderActionsBy(option => option.RelativePath);
                //var xmlPath = "F:\\C#\\API\\XinYiAPI\\bin\\Debug\\netcoreapp3.1\\XinYiAPI.xml";//这个就是刚刚配置的xml文件名
                //options.IncludeXmlComments(xmlPath, true);
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "jwt授权(数据将在请求头中进行传输)直接在下框中输入Bearer {token}（注意两者之间是一个空格）\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                }); ;
                //options.OperationFilter<AddResponseHeadersFilter>();
                //options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(MyAllowSpecificOrigins);
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "XinYiAPI");
                options.RoutePrefix = "swagger";
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
           
        }
    }
}
