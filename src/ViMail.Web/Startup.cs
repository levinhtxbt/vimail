using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using ViMail.Data;
using ViMail.Data.Entities;
using ViMail.Data.Interfaces;
using ViMail.Web.Extensions;

namespace ViMail.Web
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
            services.AddCustomizedConfigure(Configuration);

            services.AddCustomizedDataStore(Configuration);

            services.AddCustomizedIdentity();

            services.AddCookie();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
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

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<EFDbContext>()
                .As<DbContext>()
                .InstancePerLifetimeScope();
            builder.RegisterType<EFUnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(EFRepository<,>))
                .As(typeof(IRepository<,>))
                .InstancePerLifetimeScope();

            builder.RegisterType<UserManager<User>>()
                .InstancePerLifetimeScope();
            builder.RegisterType<RoleManager<Role>>()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(Assembly.Load("ViMail.Data"))
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(Assembly.Load("ViMail.Service"))
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}