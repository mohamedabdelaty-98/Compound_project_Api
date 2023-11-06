using Compound_project.Reposatories.ReviewReposatory;
using DataAccessLayer.Data;
using DataAccessLayer.Reposatories;

using Microsoft.AspNetCore.Identity;

using DataAccessLayer.Reposatories.LandmarkReposatory;
using DataAccessLayer.Reposatories.LandMarksCompoundReposatory;
using DataAccessLayer.Reposatories.ReviewReposatory;

using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace Compound_project
{
    public static class RegisterServices
    {
       
        public static WebApplicationBuilder RegsterationService(this WebApplicationBuilder builder) 
        {
            builder.Services.AddScoped<IUnit, UnitRepo>();
            builder.Services.AddScoped<IUnitComponent, UnitComponentRepo>();
            builder.Services.AddScoped<Icomponent, ComponentRepo>();

            //Configuration for Shrouk
            builder.Services.AddScoped<ICompoundImage, CompoundImageRepo>();
            builder.Services.AddScoped<IBuildingImage, BuildingImageRepo>();
            builder.Services.AddScoped<IUnitImage, UnitImageRepo>();

            //Configuration for Men3m
            builder.Services.AddScoped<ICompound, CompoundRepo>();

            //Configuration for Salah
            builder.Services.AddScoped<IServices, Services_Repo>();
            builder.Services.AddScoped<IServicesBuilding, ServicesBuilding_Repo>();
            builder.Services.AddScoped<IServicesCompound, ServicesCompound_Repo>();
            builder.Services.AddScoped<IServicesUnit, ServicesUnit_Repo>();

            //Configuration for Zaki
            builder.Services.AddScoped<IApplication, ApplicationRepo>();
            builder.Services.AddScoped<IWishList, WishListRepo>();
            builder.Services.AddScoped<IWishListUnit, WishListUnitRepo>();

            //Configuration for Raghad
            builder.Services.AddScoped<IBuilding, BuildingRepo>();

            //Configuration for Amr

            builder.Services.AddScoped<ILandmarkReposatory, LandmarkReposatory>();
            builder.Services.AddScoped<ILandMarksCompoundReposatory, LandMarksCompoundReposatory>();
            //builder.Services.AddScoped<ILandmarkReposatory, LandmarkReposatory>();
            //builder.Services.AddScoped<IGetAllDTOReposatories, GetAllDTOReposatories>();
            //builder.Services.AddScoped<ILandMarksCompoundReposatory, LandMarksCompoundReposatory>();
            builder.Services.AddScoped<IReviewReposatory, ReviewReposatory>();
            builder.Services.AddScoped<IReviewOperationsReposatory, ReviewOperationsReposatory>();


            return builder;
        }

        public static WebApplicationBuilder RegsterationDB(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<Context>(option =>
            {
                option.UseLazyLoadingProxies()
                .UseSqlServer(builder.Configuration.GetConnectionString("sql"),
                b => b.MigrationsAssembly("Compound_project"));
            });
            return builder;
        }

        public static WebApplicationBuilder RegsterationCors(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(option =>
               option.AddPolicy("AllowAnyOrigin", builder =>
               builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().WithExposedHeaders("content-disposition")
           ));
            return builder;
        }

        public static WebApplicationBuilder RegestriationIdentity(this WebApplicationBuilder builder)
        {
            builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<Context>();    
            return builder;
        }
        public static WebApplicationBuilder AuthenticationJWT(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["JWT:ValidAudiance"],
                    IssuerSigningKey =
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Securitykey"]))
                };
            });
            return builder;
        }
    }
}
