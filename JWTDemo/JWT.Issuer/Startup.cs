using AuthorizedServer.Model;
using JWT.Issuer.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JWT.Issuer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            
               Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkInMemoryDatabase().AddDbContext<JWTTokenContext>(
                options => options.UseInMemoryDatabase("JWTToken"), ServiceLifetime.Singleton);

            services.AddSingleton<IJWTTokenRepository, JWTTokenRepository>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.Configure<Audience>(Configuration.GetSection("Audience"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseMvc();

            //初始化数据
            SampleData.InitializeFortunesAsync(app.ApplicationServices).Wait();
        }
    }
}
