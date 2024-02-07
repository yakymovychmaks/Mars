using BLL.Services;
using DLL.DataAccess;
using DLL.Interface;
using DLL.Repository;
using Domain.Entity;
using Domain.Response;
using FluentAssertions.Common;
using MarsBackEnd.Utilities;
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

            #region Post DI
            builder.Services.AddScoped<PostRepository>();
            //builder.Services.AddTransient<PostService>();
            #endregion

            builder.Services.AddScoped<UserRepository>();
            builder.Services.AddScoped<IRepository<Profile>, ProfileRepository>();
            builder.Services.AddScoped<IRepository<User>, UserRepository>();
            builder.Services.AddScoped<IRepository<Apointment>, ApointmentRepository>();
            builder.Services.AddScoped<IRepository<Comment>, CommentRepository>();
            builder.Services.AddScoped<IRepository<Blog>, BlogRepository>();
            builder.Services.AddScoped<IRepository<DocsMeta>, docsMetaRepository>();
            builder.Services.AddScoped<IRepository<MemberRole>, MemberRolesRepository>();
            builder.Services.AddScoped<IRepository<Partner>, PartnerRepository>();
            builder.Services.AddScoped<IRepository<PatientWaitList>, PatientWaitListRepository>();
            builder.Services.AddScoped<IRepository<People>, PeopleRepository>();
            builder.Services.AddScoped<IRepository<Photo>, PhotoRepository>();
            builder.Services.AddScoped<IRepository<PostItem>, PostItemsRepository>();
            builder.Services.AddScoped<IRepository<Domain.Entity.Services>,  ServicesRepository>();
            builder.Services.AddScoped<IRepository<Tag>, TagRepository>();
            builder.Services.AddScoped<IRepository<Teams>, TeamsRepository>();
            builder.Services.AddScoped<IRepository<ThemesQuestion>,ThemesQuestionRepository>();
            builder.Services.AddScoped<PhotoRepository>();
            builder.Services.AddScoped<PhotoService>();
            builder.Services.AddScoped<PhotoHelper>(provider => new PhotoHelper(provider.GetRequiredService<IWebHostEnvironment>()));
            builder.Services.AddTransient<UserService>();


            builder.Services.AddControllers();
            builder.Services.AddControllers().AddJsonOptions(o => o.JsonSerializerOptions.PropertyNameCaseInsensitive = true);





            // Configure the HTTP request pipeline.

            //var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MArsIndustrys;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
                .Options;
            using (var db = new ApplicationDbContext(dbContextOptions))
            {
                db.SaveChanges();
            }

            var app = builder.Build();
            app.UseHttpsRedirection();

            app.UseAuthorization();

            //app.MapControllerRoute(name: "default", pattern: "{controller=");

            app.MapControllers();

            app.Run();
            

        }
    }
}