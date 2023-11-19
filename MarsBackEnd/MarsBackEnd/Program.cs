using BLL.Mapping;
using BLL.Services;
using DLL.DataAccess;
using FluentAssertions.Common;
using MarsBackEnd.APIServices;
using MarsBackEnd.Mapping;
using Microsoft.EntityFrameworkCore;


namespace DLL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddAutoMapper(typeof(MappingConfigs));
            builder.Services.AddTransient<AdminService>();
            builder.Services.AddTransient<AdminAPIService>();


            builder.Services.AddControllers();
            


            var app = builder.Build();

            // Configure the HTTP request pipeline.

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MArsIndustry;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
                .Options;

            app.UseHttpsRedirection();

            app.UseAuthorization();

            //app.MapControllerRoute(name: "default", pattern: "{controller=");

            app.MapControllers();

            app.Run();
            

        }
    }
}