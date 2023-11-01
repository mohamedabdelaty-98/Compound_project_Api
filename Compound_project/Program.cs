
using BussienesLayer.Reposatories;
using Compound_project.AutoMapper;
using DataAccessLayer.Data;


using DataAccessLayer.Reposatories;

using DataAccessLayer.Reposatories;
using Microsoft.EntityFrameworkCore;


namespace Compound_project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<Context>(option =>
            {
                option.UseLazyLoadingProxies()
                .UseSqlServer(builder.Configuration.GetConnectionString("sql"),
                b=>b.MigrationsAssembly("Compound_project"));
            });
            //configration for automapper
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
            //Configuration for cors
            builder.Services.AddCors(option =>
                option.AddPolicy("AllowAnyOrigin", builder =>
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader())
            );
            builder.Services.AddScoped<IUnit, UnitRepo>();
            builder.Services.AddScoped<IUnitComponent, UnitComponentRepo>();



            builder.Services.AddScoped<Icomponent, ComponentRepo>();
            
            //Configuration for Raghad





      //Configuration for Shrouk

            builder.Services.AddScoped<ICompoundImage, CompoundImageRepo>();
            builder.Services.AddScoped<IBuildingImage, BuildingImageRepo>();
            builder.Services.AddScoped<IUnitImage, UnitImageRepo>();



      //Configuration for Men3m

            builder.Services.AddScoped<ICompound, CompoundRepo>();



      //Configuration for Salah



            //Configuration for Salah
            builder.Services.AddScoped<IServices, Services_Repo>();
            builder.Services.AddScoped<IServicesBuilding, ServicesBuilding_Repo>();
            builder.Services.AddScoped<IServicesCompound, ServicesCompound_Repo>();
            builder.Services.AddScoped<IServicesUnit, ServicesUnit_Repo>();



      //Configuration for Zaki
      builder.Services.AddScoped<IApplication, ApplicationRepo>();
      builder.Services.AddScoped<IWishList,WishListRepo>();
      builder.Services.AddScoped<IWishListUnit, WishListUnitRepo>();
     





      //Configuration for Amr



      var app = builder.Build();


            //Configuration for Amr



            //var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
