using DaanPath.Entity;
using Microsoft.EntityFrameworkCore;

namespace DaanPath.Data
    {
        public class DonationAppContext : DbContext
        {
            public DonationAppContext(DbContextOptions<DonationAppContext> options) : base(options) { }

            public DbSet<User> Users { get; set; }
            public DbSet<Donation> Donations { get; set; }
            public DbSet<NGO> NGOs { get; set; }
            public DbSet<Event> Events { get; set; }
            public DbSet<Product> Products { get; set; }
            public DbSet<Vendor> Vendors { get; set; }
            public DbSet<Admin> Admins { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                // Define relationships
                modelBuilder.Entity<Donation>()
                    .HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserID);

                modelBuilder.Entity<Donation>()
                    .HasOne(d => d.NGO)
                    .WithMany()
                    .HasForeignKey(d => d.NGOID);

                modelBuilder.Entity<Product>()
                    .HasOne(p => p.Vendor)
                    .WithMany()
                    .HasForeignKey(p => p.VendorID);
            }
        }
    }
