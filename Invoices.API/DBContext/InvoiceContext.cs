using Invoice.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Invoice.API.DBContext
{
    public class InvoiceContext : DbContext
    {
        public InvoiceContext(DbContextOptions<InvoiceContext> options)
        : base(options)
        { }

        public DbSet<InvoiceEntity> Invoices { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Address data
            modelBuilder.Entity<Address>().HasData(
                new Address { Id = 1, Street = "123 Main St", City = "New York", PostCode = "10001", Country = "USA" },
                new Address { Id = 2, Street = "456 Elm St", City = "Los Angeles", PostCode = "90001", Country = "USA" },
                new Address { Id = 3, Street = "789 Pine St", City = "Chicago", PostCode = "60001", Country = "USA" },
                new Address { Id = 4, Street = "101 Maple St", City = "San Francisco", PostCode = "94101", Country = "USA" },
                new Address { Id = 5, Street = "202 Oak St", City = "Miami", PostCode = "33101", Country = "USA" },
                new Address { Id = 6, Street = "303 Birch St", City = "Seattle", PostCode = "98101", Country = "USA" },
                new Address { Id = 7, Street = "404 Cedar St", City = "Austin", PostCode = "73301", Country = "USA" },
                new Address { Id = 8, Street = "505 Pineapple St", City = "Hawaii", PostCode = "96801", Country = "USA" },
                new Address { Id = 9, Street = "606 Magnolia St", City = "Dallas", PostCode = "75201", Country = "USA" },
                new Address { Id = 10, Street = "707 Oak Tree St", City = "Atlanta", PostCode = "30301", Country = "USA" }
            );
            modelBuilder.Entity<InvoiceItem>().HasData(
               new InvoiceItem { Id = 1, Quantity = 2, Price = 40.25, InvoiceId = "INV-005", Name = "Brand Guidelines", Total = 80.50 },
               new InvoiceItem { Id = 2, Quantity = 5, Price = 20.00, InvoiceId = "INV-005", Name = "Logo Design", Total = 100.00 },
               new InvoiceItem { Id = 3, Quantity = 1, Price = 500.00, InvoiceId = "INV-006", Name = "Website Development", Total = 500.00 },
               new InvoiceItem { Id = 4, Quantity = 3, Price = 150.00, InvoiceId = "INV-006", Name = "Hosting and Maintenance", Total = 450.00 },
               new InvoiceItem { Id = 5, Quantity = 10, Price = 15.50, InvoiceId = "INV-007", Name = "Business Cards", Total = 155.00 },
               new InvoiceItem { Id = 6, Quantity = 4, Price = 75.00, InvoiceId = "INV-007", Name = "Flyer Design", Total = 300.00 },
               new InvoiceItem { Id = 7, Quantity = 6, Price = 25.00, InvoiceId = "INV-008", Name = "Social Media Posts", Total = 150.00 },
               new InvoiceItem { Id = 8, Quantity = 1, Price = 1000.00, InvoiceId = "INV-009", Name = "Marketing Campaign", Total = 1000.00 },
               new InvoiceItem { Id = 9, Quantity = 2, Price = 120.50, InvoiceId = "INV-009", Name = "SEO Optimization", Total = 241.00 },
               new InvoiceItem { Id = 10, Quantity = 8, Price = 12.00, InvoiceId = "INV-009", Name = "Product Descriptions", Total = 96.00 }
           );
            // Seed Invoice data
            modelBuilder.Entity<InvoiceEntity>().HasData(
                new InvoiceEntity
                {
                    Id = "INV-005",
                    CreatedAt = DateTime.Now,
                    PaymentDue = DateTime.Now.AddDays(14),  // Correct PaymentDue calculation
                    Description = "Consulting Services",
                    PaymentTerms = 14,
                    ClientName = "John Doe",
                    ClientEmail = "john.doe@example.com",
                    Status = "pending",
                    SenderAddressId = 1,
                    ClientAddressId = 2,
                    Total = 1500.00
                },
                new InvoiceEntity
                {
                    Id = "INV-006",
                    CreatedAt = DateTime.Now,
                    PaymentDue = DateTime.Now.AddDays(30),  // Correct PaymentDue calculation
                    Description = "Consulting Services",
                    PaymentTerms = 30,
                    ClientName = "John Doe",
                    ClientEmail = "john.doe@example.com",
                    Status = "pending",
                    SenderAddressId = 1,
                    ClientAddressId = 2,
                    Total = 1500.00
                },
                new InvoiceEntity
                {
                    Id = "INV-007",
                    CreatedAt = DateTime.Now,
                    PaymentDue = DateTime.Now.AddDays(14),  // Correct PaymentDue calculation
                    Description = "Graphic Design",
                    PaymentTerms = 14,
                    ClientName = "Sarah Lee",
                    ClientEmail = "sarah.lee@example.com",
                    Status = "pending",
                    SenderAddressId = 1,
                    ClientAddressId = 2,
                    Total = 2000.00
                },
                new InvoiceEntity
                {
                    Id = "INV-008",
                    CreatedAt = DateTime.Now,
                    PaymentDue = DateTime.Now.AddDays(14),
                    Description = "architect Design",
                    PaymentTerms = 14,
                    ClientName = "Sarah Lopez",
                    ClientEmail = "sarah.lopez@example.com",
                    Status = "pending",
                    SenderAddressId = 1,
                    ClientAddressId = 2,
                    Total = 2000.00
                },
                new InvoiceEntity
                {
                    Id = "INV-009",
                    CreatedAt = DateTime.Now,
                    PaymentDue = DateTime.Now.AddDays(14),
                    Description = "architect Design",
                    PaymentTerms = 14,
                    ClientName = "Sarah Lopez",
                    ClientEmail = "sarah.lopez@example.com",
                    Status = "pending",
                    SenderAddressId = 1,
                    ClientAddressId = 2,
                    Total = 2000.00,
                }
            );


            // Configure Relationships
            modelBuilder.Entity<InvoiceEntity>()
                .HasOne(i => i.SenderAddress)
                .WithMany()
                .HasForeignKey(i => i.SenderAddressId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<InvoiceEntity>()
                .HasOne(i => i.ClientAddress)
                .WithMany()
                .HasForeignKey(i => i.ClientAddressId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<InvoiceEntity>()
                .HasMany(i => i.Items)
                .WithOne()
                .HasForeignKey(ii => ii.InvoiceId);

        }
    }
}

