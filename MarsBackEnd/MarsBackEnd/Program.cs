using BLL.Services;
using DLL.DataAccess;
using DLL.Interface;
using DLL.Repository;
using Domain.Entity;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MarsBackEnd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Identity
            
            builder.Services.AddIdentity<User,IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            // Configure CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin", builder =>
                {
                    builder.WithOrigins("http://localhost:3000") // Frontend Domen
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });



            // Register repositories and services

            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<PhotoService>();
            builder.Services.AddScoped<PostRepository>();
            builder.Services.AddScoped<PhotoRepository>();
            builder.Services.AddScoped<IRepository<User>, UserRepository>();
            builder.Services.AddScoped<IRepository<Profile>, ProfileRepository>();
            builder.Services.AddScoped<IRepository<Apointment>, ApointmentRepository>();

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
            });
            //builder.Services.AddScoped<IRepository<Photo>, PhotoRepository>();
            // Add other repositories and services here...
            // Configure JWT authentication
            //builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options =>
            //    {
            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuer = true,
            //            ValidateAudience = true,
            //            ValidateLifetime = true,
            //            ValidateIssuerSigningKey = true,
            //            ValidIssuer = "ваш_ісюер",
            //            ValidAudience = "ваш_аудієнція",
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ваш_секретний_ключ"))
            //        };
            //    });

            // Add controllers and configure JSON serialization options
            builder.Services.AddControllers()
                .AddJsonOptions(o => o.JsonSerializerOptions.PropertyNameCaseInsensitive = true);

            // Build the app
            var app = builder.Build();

            // Configure middleware
            app.UseCors("AllowOrigin");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run();
        }
    }
}
