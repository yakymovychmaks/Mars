using Domain.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DLL.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Apointment> Apointsments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Встановлюємо правила обробки видалення для зв'язку між Apointment і Profile
            modelBuilder.Entity<Apointment>()
                .HasOne(ap => ap.Profile)
                .WithMany(p => p.Apointment)
                .HasForeignKey(ap => ap.ProfileId)
                .OnDelete(DeleteBehavior.Restrict); // Забороняє каскадне видалення

            // Додаткові налаштування таблиць і зв'язків можна додати тут

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<Blog> Blog { get; set; }
        public virtual DbSet<DocsMeta> Docs { get; set; }
        public virtual DbSet<MemberRole> MemberRoles { get; set; }
        public virtual DbSet<Partner> Partners { get; set; }
        public virtual DbSet<PatientWaitList> PatientWaitList { get; set; }
        public virtual DbSet<People> People { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<PostItem> PostItems { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }
        public virtual DbSet<ThemesQuestion> ThemesQuestions { get; set; }

    }

}
