using Covid19Statistics.Data.Repo;
using Covid19Statistics.Providers;
using Covid19Statistics.Repo;
using Covid19Statistics.Service;
using Covid19Statistics.Services;
using Covid19Statistics.Web.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Covid19Statistics.Web
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
            services.AddControllersWithViews();

            //Repositories

            services.AddScoped<ICovid19StatisticsRepo>(x=> 
                new Covid19StatisticsRepo(new Data.Covid19Api.Api(x.GetService<IHttpClientFactory>().CreateClient("AuthenticationApiCovid"))));

            services.AddScoped<IRegionsRepo>(x =>
               new RegionsRepo(new Data.Covid19Api.Api(x.GetService<IHttpClientFactory>().CreateClient("AuthenticationApiCovid"))));


            //Services
            services.AddScoped<ICovid19StatisticsService, Covid19StatisticsService>();
            services.AddScoped<IRegionsService, RegionsService>();

            //Providers
            services.AddScoped<ICsvConvertProvider, CsvConvertProvider>();
            services.AddScoped<IJsonConvertProvider, JsonConvertProvider>();
            services.AddScoped<IXmlConvertProvider, XmlConvertProvider>();

            //httpclients
            ConfigurationApiCovid configurationApiCovid = Configuration
               .GetSection("ConfigurationApiCovid").Get<ConfigurationApiCovid>();

            services.AddHttpClient("AuthenticationApiCovid", client =>
            {
                client.BaseAddress = new Uri(configurationApiCovid.UrlBaseApi);
                client.DefaultRequestHeaders.Add("x-rapidapi-key",configurationApiCovid.ApiKey);
                client.DefaultRequestHeaders.Add("x-rapidapi-host", configurationApiCovid.ApiHost);

            });

            services.AddHttpClient();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
