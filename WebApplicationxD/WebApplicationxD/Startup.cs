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
using WebApplicationxD.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApplicationxD
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false).AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddDbContext<WebApplicationxDContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("WebApplicationxDContext")));
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();

                //CreateRoles(serviceProvider);
                //CreateStartUpUsers(serviceProvider);
            });
        }

        private static void CreateRoles(IServiceProvider serviceProvider)
        {
            string[] roles = { "admin", "user" };
            foreach (string roleName in roles)
            {
                CreateRole(serviceProvider, roleName);
            }
        }

        private static void CreateRole(IServiceProvider serviceProvider, string name)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            Task<bool> roleExists = roleManager.RoleExistsAsync(name);
            roleExists.Wait();

            if (!roleExists.Result)
            {
                Task<IdentityResult> roleResult = roleManager.CreateAsync(new IdentityRole(name));
                roleResult.Wait();
            }
        }

        private static void CreateStartUpUsers(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var checkAppUser = userManager.FindByEmailAsync("administrator@admin.pl");
            checkAppUser.Wait();

            var AppUser = checkAppUser.Result;

            if (checkAppUser.Result == null)
            {
                var newAdmin = new IdentityUser
                {
                    Email = "admin@admin.pl",
                    UserName = "admin@admin.pl"
                };

                var taskCreateAdmin = userManager.CreateAsync(newAdmin, "zaq1@WSX");
                taskCreateAdmin.Wait();

                if (taskCreateAdmin.Result.Succeeded)
                {
                    AppUser = newAdmin;
                }
            }
            var asignRole = userManager.AddToRoleAsync(AppUser, "admin");
           // asignRole.Wait();

        }
    }
}
