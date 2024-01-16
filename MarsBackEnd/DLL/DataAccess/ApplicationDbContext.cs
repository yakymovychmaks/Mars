using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DLL.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }
        public virtual DbSet<User> Users { get; set; }  
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Apointment> Apointsments { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Post>()
        //        .HasOne(p => p.user)
        //        .WithMany(u => u.Posts)
        //        .HasForeignKey(p => p.UserId);

        //    modelBuilder.Entity<Apointment>()
        //        .HasOne(a => a.profiles)
        //        .WithMany(u => u.Apointments)
        //        .HasForeignKey(a => a.ProfileId);

        //    modelBuilder.Entity<Comment>()
        //        .HasOne(c => c.Post)
        //        .WithMany(u => u.Comments)
        //        .HasForeignKey(c => c.PostId);

        //    modelBuilder.Entity<User>()
        //    .HasOne(u => u.Profile)
        //    .WithOne(p => p.User)
        //    .HasForeignKey<Profile>(p => p.User);
        //}
    }
}
