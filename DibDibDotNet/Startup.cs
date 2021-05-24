using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DibDibDotNet.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DibDibDotNet
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

      services.AddCors();
      // use session
      services.AddMvc();
      services.AddDistributedMemoryCache();
      services.AddSession(options =>
      {
        options.IdleTimeout = TimeSpan.FromDays(7);
        options.IOTimeout = TimeSpan.FromDays(7);
      });


      services.AddDbContext<DibDibDotNetContext>(options => options.UseSqlite(Configuration.GetConnectionString("DibDibDotNetContext")));

      services.AddControllersWithViews();
      services.AddRazorPages();

      services
          .AddControllersWithViews()
          .AddRazorRuntimeCompilation();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
      app.UseSession();
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
        // endpoints.MapControllerRoute(
        //     name: "default",
        //     pattern: "{controller=Home}/{action=Index}/{id?}");
        endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=LoginSignup}/{action=Login}");

        endpoints.MapRazorPages();
      });
    }
  }
}