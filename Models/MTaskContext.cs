using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ManagementDesTaches.Models
{
    public class MTaskContext:IdentityDbContext<User>
    {

        public  DbSet<Mtask> Tasks { get; set; }


        public MTaskContext(DbContextOptions<MTaskContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mtask>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Mtask>()
                .Property(x => x.Priority)
                .IsRequired();
            modelBuilder.Entity<Mtask>()
                .Property(x=>x.Name)
                .IsRequired();
            modelBuilder.Entity<Mtask>()
                .Property(x=>x.Description)
                .IsRequired();
            modelBuilder.Entity<Mtask>()
                .Property(x=>x.DueDate)
                .IsRequired();
            modelBuilder.Entity<Mtask>()
                .Property(x => x.status)
                .IsRequired();
                base.OnModelCreating(modelBuilder);
        }

    }
}
