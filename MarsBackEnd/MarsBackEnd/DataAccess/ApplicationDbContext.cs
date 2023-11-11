using MarsBackEnd.Models;
using MarsBackEnd.Models.UserModel;
using Microsoft.EntityFrameworkCore;

namespace MarsBackEnd.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Apointment> Apointsments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Office> Office { get; set; }
        public DbSet<Patient> Patients { get; set; }
    }
}
