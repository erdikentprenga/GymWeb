﻿// <auto-generated />
using System;
using GymWeb.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GymWeb.Migrations
{
    [DbContext(typeof(GymManagementContext))]
    [Migration("20230826105905_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GymWeb.Entities.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Surname")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("GymWeb.Entities.MembersSubscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("DiscountValue")
                        .HasColumnType("decimal(10, 0)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<decimal>("OriginalPrice")
                        .HasColumnType("decimal(10, 0)");

                    b.Property<decimal>("PaidPrice")
                        .HasColumnType("decimal(10, 0)");

                    b.Property<int>("RemainingSessions")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("MembersSubscription", (string)null);
                });

            modelBuilder.Entity("GymWeb.Entities.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("NumberOfMonths")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfSessions")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10, 0)");

                    b.Property<int>("WeekFrequency")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("GymWeb.Entities.MembersSubscription", b =>
                {
                    b.HasOne("GymWeb.Entities.Member", "Member")
                        .WithMany("MembersSubscriptions")
                        .HasForeignKey("MemberId")
                        .IsRequired()
                        .HasConstraintName("FK_MembersSubscription_Members");

                    b.HasOne("GymWeb.Entities.Subscription", "Subscription")
                        .WithMany("MembersSubscriptions")
                        .HasForeignKey("SubscriptionId")
                        .IsRequired()
                        .HasConstraintName("FK_MembersSubscription_Subscriptions");

                    b.Navigation("Member");

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("GymWeb.Entities.Member", b =>
                {
                    b.Navigation("MembersSubscriptions");
                });

            modelBuilder.Entity("GymWeb.Entities.Subscription", b =>
                {
                    b.Navigation("MembersSubscriptions");
                });
#pragma warning restore 612, 618
        }
    }
}