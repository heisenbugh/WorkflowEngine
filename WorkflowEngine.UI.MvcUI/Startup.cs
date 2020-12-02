using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WorkflowEngine.BussinessLogicLayer.Services;
using WorkflowEngine.Core.UnitOfWork;
using WorkflowEngine.Core.Services;
using WorkflowEngine.DataAccessLayer.DbContexts;
using WorkflowEngine.DataAccessLayer.UnitOfWorks;
using WorkflowEngine.Core.Repositories;
using WorkflowEngine.Core.Entities;
using WorkflowEngine.DataAccessLayer.Repositories;

namespace WorkflowEngine.UI.MvcUI
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
            services.AddControllersWithViews();

            services.AddDbContext<EfCoreOracleWorkflowEngineDbContext>(options => options.UseOracle(Configuration.GetConnectionString("ConnectionString")));
            
            services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();
            services.AddScoped<IBaseRepository<Core.Entities.Action>, BaseRepository<Core.Entities.Action>>();
            services.AddScoped<IBaseRepository<Path>, BaseRepository<Path>>();
            services.AddScoped<IBaseRepository<PathUser>, BaseRepository<PathUser>>();
            services.AddScoped<IBaseRepository<Process>, BaseRepository<Process>>();
            services.AddScoped<IBaseRepository<ProcessAdmin>, BaseRepository<ProcessAdmin>>();
            services.AddScoped<IBaseRepository<Progress>, BaseRepository<Progress>>();
            services.AddScoped<IBaseRepository<Request>, BaseRepository<Request>>();
            services.AddScoped<IBaseRepository<State>, BaseRepository<State>>();
            services.AddScoped<IBaseRepository<StateUser>, BaseRepository<StateUser>>();

            services.AddScoped<IWorkflowEngineUnitOfWork, WorkflowEngineUnitOfWork>();
            
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IWorkflowEngineService, WorkflowEngineService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
