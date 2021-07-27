using Listen_Music.Application.Interfaces.Context;
using Listen_Music.Application.Interfaces.FacadePatterns;
using Listen_Music.Application.Services.Common.Queries.GetMemuItems;
using Listen_Music.Application.Services.Common.Queries.GetReport;
using Listen_Music.Application.Services.Songs.FacadePatern;
using Listen_Music.Application.Services.Songs.Queries.GetMostView;
using Listen_Music.Application.Services.Songs.Queries.GetPlayListForSite;
using Listen_Music.Application.Services.Songs.Queries.GetSongsOfPlayList;
using Listen_Music.Application.Services.UserProfiles;
using Listen_Music.Application.Services.Users.Commands.EditUser;
using Listen_Music.Application.Services.Users.Commands.Register;
using Listen_Music.Application.Services.Users.Commands.RemoveUser;
using Listen_Music.Application.Services.Users.Commands.UserLogin;
using Listen_Music.Application.Services.Users.Queries.GetRoles;
using Listen_Music.Application.Services.Users.Queries.GetUser;
using Listen_Music.Persistance.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPiont.Listen_Music
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
            services.AddAuthentication(option =>
            {
                option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(option =>
            {
                option.LoginPath = new PathString("/");
                option.ExpireTimeSpan = TimeSpan.FromMinutes(10.0);
            });

            services.AddScoped<IDataBaseContext, DataBaseContext>();
            services.AddScoped<IGetUserService, GetUserService>();
            services.AddScoped<IGetRolesService, GetRolesService>();
            services.AddScoped<IRegisterUserService, RegisterUserService>();
            services.AddScoped<IRemoveUserService, RemoveUserService>();
            services.AddScoped<IEditUserService, EditUserService>();
            services.AddScoped<IUserLoginService, UserLoginService>();

            //----Facad Pattern--------------------
            services.AddScoped<ISongFacade, SongFacade>();

            //------menu items-------------------
            services.AddScoped<IGetMemuItemService, GetMemuItemService>();

            //---------most view------------------
            services.AddScoped<IGetMostViewService, GetMostViewService>();

            //------play lists------------------
            services.AddScoped<IGetPlayListForSiteService, GetPlayListForSiteService>();

            //--------Favorites-------------------
            services.AddScoped<ISingerFollowService, SingerFollowService>();
            services.AddScoped<IGenreFollowService, GenreFollowService>();
            services.AddScoped<IPlayListFollowService, PlayListFollowService>();

            //----------Reports----------------------
            services.AddScoped<IGetReportForAdmin, GetReportForAdmin>();

            string ConnectionString = @"Data Source=.; Initial Catalog=Listen_music; Integrated Security=true;";
            services.AddEntityFrameworkSqlServer().AddDbContext<DataBaseContext>(option => option.UseSqlServer(ConnectionString));
            services.AddControllersWithViews();
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

            app.UseAuthentication();
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
