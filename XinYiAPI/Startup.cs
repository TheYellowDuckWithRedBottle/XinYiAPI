using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using XinYiAPI.Services;
using XinYiAPI.DataAccess.Base;
using System.IO;

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
            services.AddControllers();
            //services.AddAuthentication("Bearer")
            //   .AddJwtBearer("Bearer", options =>
            //   {
            //       options.Authority = "http://localhost:3000";
            //       options.RequireHttpsMetadata = false;
            //       options.Audience = "api1";     
            //   });

            services.AddDbContext<AlanContext>(options =>
                               options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            });
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
                var xmlPath = "F:\\C#\\API\\XinYiAPI\\bin\\Debug\\netcoreapp3.1\\XinYiAPI.xml";//这个就是刚刚配置的xml文件名
                options.IncludeXmlComments(xmlPath, true);

                options.OperationFilter<AddResponseHeadersFilter>();
                options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
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
            app.UseHttpsRedirection();
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
