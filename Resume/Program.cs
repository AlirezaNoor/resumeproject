using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using RES.Domin.Identity;
using RES.FrameWorke;
using RES.Infrastructure.Context;
using RES.Query.Queryclass;
using RES.Query.QueryInterface;
using RES.Services.Class;
using RES.Services.Class.CustomRepository;
using RES.Services.Class.UploadFile;
using RES.Services.Interface;
using RES.Services.Interface.CustomRepository;
using RES.Services.Interface.UploadFile;

namespace Resume
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var address = builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(FileNames.Applicationstting).Build();
            #region MyRegion

            builder.Services.getmyconfig(address);
            builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(opt =>
                {
                    opt.Password.RequireDigit = false;
                    opt.Password.RequireLowercase = false;
                    opt.Password.RequireLowercase = false;
                    opt.Password.RequireNonAlphanumeric = false;
                    opt.Password.RequireUppercase = false;
                }).AddRoles<ApplicationRole>()
                .AddRoleValidator<RoleValidator<ApplicationRole>>()
                .AddRoleManager<RoleManager<ApplicationRole>>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddSignInManager<SignInManager<ApplicationUser>>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<ITransation, Transation>();
            builder.Services.AddScoped<IFilenames, Filenames>();
            builder.Services.AddScoped<IUplodCvFile, UplodCvFile>();
            builder.Services.AddScoped<IIdoRepository, IdoRepository>();
            builder.Services.AddScoped<IRsumeQuery, RsumeQuery>();
            #endregion
            builder.Services.ConfigureApplicationCookie(options =>
                {
                    options.LoginPath = "/Administrator/Account/index";
                    options.LogoutPath = "/Administrator/Account/Logout";
                }
            
            );
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
            app.Run();
        }
    }
}