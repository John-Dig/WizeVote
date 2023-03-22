using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vote.Models;
using Microsoft.AspNetCore.Identity;

namespace WizeVote
{
  class Program
  {
    static void Main(string[] args)
    {

      WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

      builder.Services.AddControllersWithViews();

      builder.Services.AddDbContext<VoteContext>(
                       dbContextOptions => dbContextOptions
                         .UseMySql(
                           builder.Configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(builder.Configuration["ConnectionStrings:DefaultConnection"]
                         )
                       )
                     );
      builder.Services.AddIdentity<ApplicationUser, IdentityRole>()//added for identity
                .AddEntityFrameworkStores<VoteContext>()//added for identity
                .AddDefaultTokenProviders();//added for identity

      WebApplication app = builder.Build();

      // app.UseDeveloperExceptionPage();
      app.UseHttpsRedirection();
      app.UseStaticFiles();

      app.UseRouting();

      app.UseAuthentication(); //added for identity
      app.UseAuthorization(); //added for identity

      app.MapControllerRoute(
          name: "default",
          pattern: "{controller=Home}/{action=Index}/{id?}"
          );

      app.Run();
    }
  }
}