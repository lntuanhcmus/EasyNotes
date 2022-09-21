using EasyNotes.Data.EntityFramework;
using EasyNotes.Data.Models;
using EasyNotes.WebHost.IdentityServer;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNotes.WebHost.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomizedIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;

                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });
            services.AddIdentity<AppUser, AppRole>()
                    .AddEntityFrameworkStores<AppDbContext>()
                    .AddDefaultTokenProviders();
            
            services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
            })
                    .AddInMemoryClients(IdentityServerConfig.Clients)
                    .AddInMemoryIdentityResources(IdentityServerConfig.Ids)
                    .AddInMemoryApiResources(IdentityServerConfig.Apis)
                    .AddInMemoryApiScopes(IdentityServerConfig.ApiScopes)
                    .AddDeveloperSigningCredential();
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = ("/Identity/Account/Login");
            });

            return services;
        }    
    }
}
