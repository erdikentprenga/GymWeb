using GymWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace GymWeb.Context
{
    public partial class GymContext : DbContext
    {
        public GymContext()
        {
           
        }

        public GymContext(DbContextOptions<GymContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Members> Members { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Members>(entity =>
            {   
                entity.Property(e => e.Id).HasMaxLength(4);

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.Surname).HasMaxLength(20);

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.Registration).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.IsDeleted).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<GymWeb.Models.Subscriptions> Subscriptions { get; set; } = default!;

        public DbSet<GymWeb.Models.MembersSubscription> MembersSubscription { get; set; } = default!;

    }
}
