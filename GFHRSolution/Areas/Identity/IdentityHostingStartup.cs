using System;
using GFHRSolution.Areas.Identity.Data;
using GFHRSolution.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(GFHRSolution.Areas.Identity.IdentityHostingStartup))]
namespace GFHRSolution.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<GFHRIdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("GFHRContextConnection")));

                services.AddDefaultIdentity<GFHRSolutionUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<GFHRIdentityContext>();
            });
        }
    }
}