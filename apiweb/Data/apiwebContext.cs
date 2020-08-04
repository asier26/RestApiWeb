using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using apiweb;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
                entity.ToTable("Customer");
                entity.HasKey(e => e.CustomerId);
                entity.Property(e => e.CustomerId).HasColumnName("CustomerId");

                entity.Property(e => e.PostalCode)
                .HasColumnName("PostalCode")
                .IsRequired()
                .HasMaxLength(5)
                .IsUnicode(false);

                entity.Property(e => e.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.Surname)
                .HasColumnName("Surname")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.Age)
                .HasColumnName("Age")
                .IsRequired()
                .HasMaxLength(3)
                .IsUnicode(false);

                entity.Property(e => e.Date)
                .HasColumnName("Date")
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("getdate()"); ;

                entity.Property(e => e.Email)
                .HasColumnName("Email")
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
                entity.HasIndex(e => e.Email).IsUnique();

                entity.Property(e => e.Estate)
                .IsRequired()
                .HasColumnName("Estate")
                .HasDefaultValueSql("((1))");
            });
        }
    }
}
