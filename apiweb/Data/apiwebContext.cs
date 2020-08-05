using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using apiweb;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ApiWeb.Models;

namespace apiweb.Data
{
    public class apiwebContext : DbContext
    {
        public apiwebContext()
        {

        }
        public apiwebContext (DbContextOptions<apiwebContext> options)
            : base(options)
        {

        }

        public DbSet<Customer> Customer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
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
        }

        public DbSet<ApiWeb.Models.User> User { get; set; }
    }
}
