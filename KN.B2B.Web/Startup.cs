using KN.B2B.Data;
using KN.B2B.Data.Repository;
using KN.B2B.Data.Repository.SqlServer;
using KN.B2B.Web.Data;
using KN.Messaging.SendGrid;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KN.B2B.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //Contexts
            //---- Local Test
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("DefaultConnection")));
            //services.AddDbContextPool<B2BDbContext>(options =>
            //{
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("KN.B2B.Web"));
            //});

            //---- Prod
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("ProdConnection")));
            services.AddDbContextPool<B2BDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ProdConnection"), b => b.MigrationsAssembly("KN.B2B.Web"));
            });


            //Identity
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>() //Allow role authorization - https://docs.microsoft.com/en-us/aspnet/core/security/authorization/roles?view=aspnetcore-3.1
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddRazorPages(options => 
            {
                options.Conventions.AuthorizeFolder("/Private");
            });

            //Dependency Injection
            services.AddScoped<IRequestData, MsSqlRequestData>();
            //further information can be found on: https://docs.microsoft.com/en-us/aspnet/core/security/authentication/accconfirm?view=aspnetcore-5.0&tabs=visual-studio
            services.AddScoped<IEmailSender>(sender => new EmailSender(Configuration["SendGrid"], Configuration["DefaultSender"], Configuration["AppName"]));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
