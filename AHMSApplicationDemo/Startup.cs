using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using AHMSApplicationDemo.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace AHMSApplicationDemo
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
           /* List<CultureInfo> supportedCultures = new List<CultureInfo>
            {
                new CultureInfo("en"),
                new CultureInfo("ps"),
                new CultureInfo("fa")
            };

            services.Configure<RequestLocalizationOptions>(options =>
            {
                List<CultureInfo> supportedCultures = new List<CultureInfo>
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("ps-AF"),
                    new CultureInfo("fa-IR")
                };
                options.DefaultRequestCulture = new RequestCulture("en-US");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
            services.AddLocalization(opt => { opt.ResourcesPath = "Resources"; });
            services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();
*/
           /* services.Configure<RequestLocalizationOptions>(
                opt =>
                {
              
                    var supportedCultures = new List<CultureInfo>
                    {
                        new CultureInfo("en"),
                        new CultureInfo("fa"),
                        new CultureInfo("ps")
                    };
                    opt.DefaultRequestCulture = new RequestCulture("ps");
                    opt.SupportedCultures = supportedCultures;
                    opt.SupportedUICultures = supportedCultures;
                });
            */

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
           // services.AddIdentity<ApplicationUser, IdentityRole>();
         /*   services.ConfigureApplicationCookie(option =>
            {
                option.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None;
            });*/
            services.AddIdentity<IdentityUser, IdentityRole>().AddSignInManager()
                .AddRoles<IdentityRole>().
                AddDefaultUI()
               // .AddDefaultUI(UIFrameworkAttribute.Bootstrap3)
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddMvc().AddRazorPagesOptions(Options =>
            {
                Options.Conventions.AddAreaPageRoute("Identity", "/Account/Login", "");


             /*   services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
                AddCookie(Options =>
                {
                    Options.LoginPath = "/Home/Login";
                });*/
             /*   services.AddMvc(). AddMvcOptions(MvcOption=>
                {
                    MvcOption.EnableEndpointRouting = false;
                });
*/
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

          

       
         /*   var culture = new List<CultureInfo> {
                new  CultureInfo("en-US"),
            new CultureInfo("ps-AF")
            };
            app.UseRequestLocalization(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("ps");
                options.SupportedCultures = culture;
                options.SupportedUICultures = culture;
            });
            app.UseRequestLocalization(app.ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);
            var supportedCultres = new[] { "en", "ps", "fa" };
            var localizationOption = new RequestLocalizationOptions().SetDefaultCulture(supportedCultres[1])
                .AddSupportedCultures(supportedCultres)
                .AddSupportedUICultures(supportedCultres);

            app.UseRequestLocalization(localizationOption);
*/

            app.UseAuthentication();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

        }
    }
}
