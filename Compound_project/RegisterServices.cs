using DataAccessLayer.Data;
using DataAccessLayer.Reposatories;
using Microsoft.EntityFrameworkCore;

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
               builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader())
           );
            return builder;
        }
    }
}
