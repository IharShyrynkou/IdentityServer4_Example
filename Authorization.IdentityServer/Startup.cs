using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

using Authorization.IdentityServer.Data;
using Authorization.IdentityServer.Infrastructure;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace Authorization.IdentityServer
{
    public class Startup
    {
        private readonly IHostEnvironment _environment;

        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IHostEnvironment environment)
        {
            _environment = environment;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(config =>
            {
                // When using real SQL server
                //config.UseSqlServer(Configuration.GetConnectionString(nameof(ApplicationDbContext)));
                config.UseInMemoryDatabase("DEMO_ONLY");
            })
                .AddIdentity<IdentityUser, IdentityRole>(config =>
                {
                    config.Password.RequireDigit = false;
                    config.Password.RequireLowercase = false;
                    config.Password.RequireNonAlphanumeric = false;
                    config.Password.RequireUppercase = false;
                    config.Password.RequiredLength = 6;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.ConfigureApplicationCookie(config =>
            {
                //config.LoginPath = "/Auth/Login";
                //config.LogoutPath = "/Auth/Logout";
                config.Cookie.Name = "IdentityServer.Cookies";
                config.Cookie.SameSite = SameSiteMode.None;
            });

            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            // var filePath = Path.Combine(_environment.ContentRootPath, "IdentityServer4_certificate.pfx");
            // var certificate = new X509Certificate2(filePath, "P@55w0rd");

            services.AddIdentityServer(options =>
                {
                    options.Authentication.CookieSameSiteMode = SameSiteMode.None;
                    options.Authentication.CheckSessionCookieSameSiteMode = SameSiteMode.None;
                })
                .AddAspNetIdentity<IdentityUser>()
                //.AddConfigurationStore(options =>
                //{
                //    options.ConfigureDbContext = b =>
                //        b.UseSqlServer(Configuration.GetConnectionString(nameof(ApplicationDbContext)),
                //            sql => sql.MigrationsAssembly(migrationsAssembly));
                //})
                //.AddOperationalStore(options =>
                //{
                //    options.ConfigureDbContext = b =>
                //        b.UseSqlServer(Configuration.GetConnectionString(nameof(ApplicationDbContext)),
                //            sql => sql.MigrationsAssembly(migrationsAssembly));
                //})
                .AddInMemoryClients(IdentityServerConfiguration.GetClients())
                .AddInMemoryApiResources(IdentityServerConfiguration.GetApiResources())
                .AddInMemoryIdentityResources(IdentityServerConfiguration.GetIdentityResources())
                .AddInMemoryApiScopes(IdentityServerConfiguration.GetApiScopes()) // IdentityServer4 version 4.x.x changes
                .AddProfileService<ProfileService>()
                // .AddSigningCredential(certificate);
                .AddDeveloperSigningCredential();

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.Unspecified;
                options.Secure = CookieSecurePolicy.SameAsRequest;
                options.OnAppendCookie = cookieContext =>
                    AuthenticationHelpers.CheckSameSite(cookieContext.Context, cookieContext.CookieOptions);
                options.OnDeleteCookie = cookieContext =>
                    AuthenticationHelpers.CheckSameSite(cookieContext.Context, cookieContext.CookieOptions);
            });


            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCookiePolicy(new CookiePolicyOptions
            {
                Secure = CookieSecurePolicy.Always,
                MinimumSameSitePolicy = SameSiteMode.None
            });
            app.UseIdentityServer();

            app.UseCookiePolicy(new CookiePolicyOptions
            {
                Secure = CookieSecurePolicy.Always,
                MinimumSameSitePolicy = SameSiteMode.None
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }

    public static class AuthenticationHelpers
    {
        public static void CheckSameSite(HttpContext httpContext, CookieOptions options)
        {
            if (options.SameSite != SameSiteMode.None)
                return;
            string userAgent = httpContext.Request.Headers["User-Agent"].ToString();
            if (httpContext.Request.IsHttps && !AuthenticationHelpers.DisallowsSameSiteNone(userAgent))
                return;
            options.SameSite = SameSiteMode.Unspecified;
        }

        public static bool DisallowsSameSiteNone(string userAgent) => userAgent.Contains("CPU iPhone OS 12") || userAgent.Contains("iPad; CPU OS 12") || userAgent.Contains("Macintosh; Intel Mac OS X 10_14") && userAgent.Contains("Version/") && userAgent.Contains("Safari") || userAgent.Contains("Chrome/5") || userAgent.Contains("Chrome/6");
    }
}
