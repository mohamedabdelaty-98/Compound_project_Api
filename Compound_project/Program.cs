
using BussienesLayer.Reposatories;
using Compound_project.AutoMapper;
using DataAccessLayer.Data;
//<<<<<<< Updated upstream


//=======
using DataAccessLayer.Reposatories;
//>>>>>>> Stashed changes
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
//<<<<<<< Updated upstream
//=======
            //configration for automapper
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
            //Configuration for cors
            builder.Services.AddCors(option =>
                option.AddPolicy("AllowAnyOrigin", builder =>
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader())
            );
            builder.Services.AddScoped<IUnit, UnitRepo>();
            builder.Services.AddScoped<IUnitComponent, UnitComponentRepo>();
            //Configuration for Raghad





            //Configuration for Shrouk




            //Configuration for Men3m



            //Configuration for Salah
            builder.Services.AddScoped<IServices, Services_Repo>();
            builder.Services.AddScoped<IServicesBuilding, ServicesBuilding_Repo>();
            builder.Services.AddScoped<IServicesCompound, ServicesCompound_Repo>();
            builder.Services.AddScoped<IServicesUnit, ServicesUnit_Repo>();


            //Configuration for Zaki




            //Configuration for Amr


//>>>>>>> Stashed changes
            var app = builder.Build();

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