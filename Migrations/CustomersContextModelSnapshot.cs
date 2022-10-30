﻿// <auto-generated />
using BSynchro_RJP.Models.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BSynchro_RJP.Migrations
{
    [DbContext(typeof(CustomersContext))]
    partial class CustomersContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BSynchro_RJP.Models.Entities.AccountTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("AccountsTransactions");
                });

            modelBuilder.Entity("BSynchro_RJP.Models.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BSynchro_RJP.Models.Entities.UserAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UsersAccounts");
                });

            modelBuilder.Entity("BSynchro_RJP.Models.Entities.AccountTransaction", b =>
                {
                    b.HasOne("BSynchro_RJP.Models.Entities.UserAccount", null)
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BSynchro_RJP.Models.Entities.UserAccount", b =>
                {
                    b.HasOne("BSynchro_RJP.Models.Entities.User", null)
                        .WithMany("Accounts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BSynchro_RJP.Models.Entities.User", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("BSynchro_RJP.Models.Entities.UserAccount", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
