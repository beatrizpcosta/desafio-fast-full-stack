using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Workshops.Data;
using Workshops.Repositorios;
using Workshops.Repositórios.Interfaces;

namespace Workshops
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddEntityFrameworkSqlServer()
              .AddDbContext<WorkshopsDB>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
            );  

           

            builder.Services.AddScoped<IColaborador, ColaboradorRepositorio>();
            builder.Services.AddScoped<IWorkshop, WorkshopRepositorio>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
