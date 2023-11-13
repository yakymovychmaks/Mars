using DLL.Models.AdminsModel;
using DLL.Models.UserModel;
using Microsoft.EntityFrameworkCore;

namespace DLL.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Apointment> Apointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Office> Office { get; set; }
        public DbSet<Patient> Patients { get; set; }
    }
}
