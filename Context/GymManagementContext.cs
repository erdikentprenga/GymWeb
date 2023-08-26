using System;
using System.Collections.Generic;
using GymWeb.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GymWeb.Context;

public partial class GymManagementContext : IdentityDbContext
{
    public GymManagementContext()
    {
    }

    public GymManagementContext(DbContextOptions<GymManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<MembersSubscription> MembersSubscriptions { get; set; }

    public virtual DbSet<Subscription> Subscriptions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=GymManagement;Trusted_Connection=True;TrustServerCertificate=Yes;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Member>(entity =>
        {
            entity.Property(e => e.Birthday).HasColumnType("datetime2");
            entity.Property(e => e.Email).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.RegistrationDate).HasColumnType("datetime2");
            entity.Property(e => e.Surname).HasMaxLength(250);
        });

        modelBuilder.Entity<MembersSubscription>(entity =>
        {
            entity.ToTable("MembersSubscription");

            entity.Property(e => e.DiscountValue).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.EndDate).HasColumnType("datetime2");
            entity.Property(e => e.OriginalPrice).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.PaidPrice).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.StartDate).HasColumnType("datetime2");

            entity.HasOne(d => d.Member).WithMany(p => p.MembersSubscriptions)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MembersSubscription_Members");

            entity.HasOne(d => d.Subscription).WithMany(p => p.MembersSubscriptions)
                .HasForeignKey(d => d.SubscriptionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MembersSubscription_Subscriptions");
        });

        modelBuilder.Entity<Subscription>(entity =>
        {
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 0)");
        });


        base.OnModelCreating(modelBuilder); 
    }
}
