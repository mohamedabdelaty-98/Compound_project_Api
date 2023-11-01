using BussienesLayer.Reposatories;
using Compound_project.AutoMapper;
using Compound_project.Reposatories.LandmarkReposatory;
using Compound_project.Reposatories.Landmarks;
using Compound_project.Reposatories.LandMarksCompoundReposatory;
using Compound_project.Reposatories.ReviewReposatory;
using DataAccessLayer.Data;
using DataAccessLayer.Reposatories.LandmarkReposatory;
using DataAccessLayer.Reposatories.LandMarksCompoundReposatory;
using DataAccessLayer.Reposatories.ReviewReposatory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;

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
            //for test autorize in swagger
            builder.Services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version="v1",
                    Title="Asp.Net 6 Web Api",
                    Description="Compound Project"
                });
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name="Authorization",
                    Type=SecuritySchemeType.ApiKey,
                    BearerFormat="JWT",
                    In=ParameterLocation.Header,
                    Description="Enter Bearer [space] and then your valid token in the text input "
                });
            });
            //configration for dbcontext
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

         //Configuration for Raghad





         //Configuration for Shrouk




         //Configuration for Men3m



         //Configuration for Salah




         //Configuration for Zaki




         //Configuration for Amr

         builder.Services.AddScoped<ILandmarkOperationsReposatory, LandmarkOperationsReposatory>();
         builder.Services.AddScoped<ILandmarksCompoundOperationsReposatory, LandmarksCompoundOperationsReposatory>();
         builder.Services.AddScoped<ILandmarkReposatory, LandmarkReposatory>();
         builder.Services.AddScoped<IGetAllDTOReposatories, GetAllDTOReposatories>();
         builder.Services.AddScoped<ILandMarksCompoundReposatory, LandMarksCompoundReposatory>();
         builder.Services.AddScoped<IReviewReposatory, ReviewReposatory>();
         builder.Services.AddScoped<IReviewOperationsReposatory, ReviewOperationsReposatory>();

         

         var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("AllowAnyOrigin");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}