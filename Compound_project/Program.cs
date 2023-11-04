
using BussienesLayer.AutoMapper;
using DataAccessLayer.Data;
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
  
            //Configration for DB
            builder.RegsterationDB();

            //configration for automapper
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

         //Configuration for Amr

         builder.Services.AddScoped<ILandmarkOperationsReposatory, LandmarkOperationsReposatory>();
         builder.Services.AddScoped<ILandmarksCompoundOperationsReposatory, LandmarksCompoundOperationsReposatory>();
         builder.Services.AddScoped<ILandmarkReposatory, LandmarkReposatory>();
         builder.Services.AddScoped<IGetAllDTOReposatories, GetAllDTOReposatories>();
         builder.Services.AddScoped<ILandMarksCompoundReposatory, LandMarksCompoundReposatory>();
         builder.Services.AddScoped<IReviewReposatory, ReviewReposatory>();
         builder.Services.AddScoped<IReviewOperationsReposatory, ReviewOperationsReposatory>();

         
            //Configuration for cors
            builder.RegsterationCors();

            //Configuration for Services
            builder.RegsterationService();

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
