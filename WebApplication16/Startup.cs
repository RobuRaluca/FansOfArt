using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using WebApplication16.Models;
using Stripe;
using WebApplication16.Data;
using WebApplication16.Services;
using WebApplication16.Services.Interfaces;

namespace WebApplication16
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
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddDbContext<ApplicationUser>(options => options.UseSqlServer(Configuration.GetConnectionString("MyConnection")));
            services.AddDbContext<ApplicationResource>(options => options.UseSqlServer(Configuration.GetConnectionString("ResourceConnection")));
           // services.AddDbContext<ApplicationContributionPayments>(options => options.UseSqlServer(Configuration.GetConnectionString("ContributionPaymentConnection")));
            services.AddDbContext<ApplicationContributionPayments2>(options => options.UseSqlServer(Configuration.GetConnectionString("ContributionPaymentConnection")));
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.Configure<StripeSettings>(Configuration.GetSection("Stripe"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            StripeConfiguration.SetApiKey(Configuration.GetSection("Stripe")["SecretKey"]);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    //template: "{controller=UserRegistration}/{action=CreateUser}/{id?}");
                    template: "{controller=AddNewPayments2}/{action=Create}/{id?}");
                   // template: "{controller=PayPal}/{action=CreateResource}/{id?}");
            });
        }
    }
}
