using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ITIMM.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ITIMM
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

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySQL(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddDefaultIdentity<IdentityUser>().AddRoles<IdentityRole>()
         .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            CreateRoles(serviceProvider);
        }

        //This method creates roles and a super user for creating rest of the users.
        public  void CreateRoles(IServiceProvider serviceProivder)
        {
            var roleManager = serviceProivder.GetService<RoleManager<IdentityRole>>();
            var userManager = serviceProivder.GetService<UserManager<IdentityUser>>();
            string[] roleNames = { "Admin", "AMC", "Custodian" };
            foreach (var role in roleNames)
            {
                Task<bool> isroleExsist =  roleManager.RoleExistsAsync(role);
                isroleExsist.Wait();
                if (!isroleExsist.Result)
                {
                    Task<IdentityResult> data=roleManager.CreateAsync(new IdentityRole(role));
                    data.Wait();
                }
            }
            // Creating superuser for app maintenance purpose
            string userName = Configuration.GetSection("AdminUser").Value;
            string userPWD = Configuration.GetSection("AdminPassword").Value;
            string userEmail = Configuration.GetSection("AdminEmail").Value; 
            var powerUser = new IdentityUser();
            powerUser.UserName = userName;
            powerUser.Email = userEmail;
            Task<IdentityUser> user = userManager.FindByNameAsync(userName);
            user.Wait();
            if (user.Id>0)
            {
                var adminUser= userManager.CreateAsync(powerUser, userPWD);
                if(adminUser!=null)
                {
                    Task<IdentityResult> data=userManager.AddToRoleAsync(powerUser, "Admin");
                    data.Wait();
                }
            }
        }
    }
}
