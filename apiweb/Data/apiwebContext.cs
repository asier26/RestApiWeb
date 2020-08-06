using System;
using ApiWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiWeb.Data
{
    public class ApiWebContext : DbContext
    {
        public ApiWebContext()
        {
        }
        public ApiWebContext (DbContextOptions<ApiWebContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                //Customer Model
                entity.ToTable("customer");
                entity.HasKey(e => e.CustomerId);
                entity.Property(e => e.CustomerId).HasColumnName("customerId");

                entity.Property(e => e.PostalCode)
                .HasColumnName("postalCode")
                .IsRequired()
                .HasMaxLength(5)
                .IsUnicode(false);

                entity.Property(e => e.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.Surname)
                .HasColumnName("surname")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.Age)
                .HasColumnName("age")
                .IsRequired()
                .HasMaxLength(3)
                .IsUnicode(false);

                entity.Property(e => e.Date)
                .HasColumnName("date")
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("getdate()"); ;

                entity.Property(e => e.Email)
                .HasColumnName("email")
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
                entity.HasIndex(e => e.Email).IsUnique();

                entity.Property(e => e.State)
                .IsRequired()
                .HasColumnName("state")
                .HasDefaultValueSql("((1))");
            });

            //User Model
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.UserId).HasColumnName("userId");
                //crear propiedad como unica, no puede haber 2 nombres iguales
                entity.Property(e => e.UserName)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.Password)
                .HasColumnName("password")
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);

                entity.Property(e => e.Token)
                .HasColumnName("token")
                .HasMaxLength(300)
                .IsUnicode(false);

                entity.Property(e => e.UserValid)
                .IsRequired()
                .HasColumnName("isValid")
                .HasDefaultValueSql("((0))");

                entity.Property(e => e.State)
                .IsRequired()
                .HasColumnName("state")
                .HasDefaultValueSql("((1))");
            });
        }

    }
}
