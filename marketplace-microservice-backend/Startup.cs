using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.AspNetCore.StaticFiles;
using marketplace_microservice_backend.DataAccess;
using marketplace_microservice_backend.BussinessLayer;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Swagger;

namespace marketplace_microservice_backend
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // var constr = Configuration.GetConnectionString("Alldb");

            //services.AddDbContext<AllDbContxt>(options => options.UseSqlServer(constr));
            services.AddScoped<AllDbContext>();
            services.AddScoped<IIntegration, Integration>();
            services.AddScoped<IIssueRepository, IssueRepository>();

            services.AddScoped<IIntegrationService, IntegrationService>();
            services.AddScoped<IIssueservice, IssueService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Values Api", Version = "v1" });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // app.UseHttpsRedirection();
            //app.UseStaticFiles();
            //app.UseCookiePolicy();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Values Api V1");
            });
            app.UseCors(builder => builder.WithOrigins("http://localhost:4200")
           .AllowAnyHeader().AllowAnyMethod());

            app.UseMvc();
            app.UseDefaultFiles();
        }
    }
}
