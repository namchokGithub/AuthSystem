using System;
using Identity.Areas.Identity.Data;
using Identity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Identity.Areas.Identity.IdentityHostingStartup))]
namespace Identity.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            services.AddDbContext<AuthDbContext>(options =>
                options.UseSqlServer(
                    context.Configuration.GetConnectionString("AuthDbContextConnection")));

            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            })

                    .AddEntityFrameworkStores<AuthDbContext>();
            });
        }
    }
}