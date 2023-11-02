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
            builder.Services.AddSwaggerGen();

            //Configration for DB
            builder.RegsterationDB();


            //Configration for Identity
            builder.RegestriationIdentity();


            //configration for automapper
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

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
