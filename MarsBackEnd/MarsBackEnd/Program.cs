using BLL.Mapping;
using BLL.Services;
using DLL.DataAccess;
using DLL.Repository;
using FluentAssertions.Common;
using MarsBackEnd.APIServices;
using MarsBackEnd.Mapping;
using Microsoft.EntityFrameworkCore;


namespace MarsBackEnd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MArsIndustrys;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));

            builder.Services.AddAutoMapper(typeof(MappingProfile), typeof(MappingConfigs));

            #region Post DI
            builder.Services.AddScoped<PostRepository>();
            builder.Services.AddTransient<PostService>();
            #endregion

            builder.Services.AddScoped<AdminRepository>();
            builder.Services.AddTransient<AdminAPIService>();
            builder.Services.AddTransient<AdminService>();



            builder.Services.AddControllers();





            // Configure the HTTP request pipeline.

            //var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            //var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            //    .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MArsIndustrys;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
            //    .Options;
            //using (var db = new ApplicationDbContext(dbContextOptions))
            //{
            //    db.SaveChanges();
            //}

            var app = builder.Build();
            app.UseHttpsRedirection();

            app.UseAuthorization();

            //app.MapControllerRoute(name: "default", pattern: "{controller=");

            app.MapControllers();

            app.Run();
            

        }
    }
}