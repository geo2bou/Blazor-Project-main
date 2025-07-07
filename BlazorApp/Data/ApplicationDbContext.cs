using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }  // Assuming you have a Customer model

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = Guid.Parse("C1FC9E07-98D2-48D2-8B83-FD1DEB6A0642"), CompanyName = "Boura 1", ContactName = "George 1", Address = "Papanastasiou 1", City = "Ioannina", Region = "GR", PostalCode = "45221", Country = "Greece", Phone = "6953" },
                new Customer { Id = Guid.Parse("7D146789-708D-47B5-AAD4-CD77ABB89D00"), CompanyName = "Boura 2", ContactName = "George 2", Address = "Papanastasiou 2", City = "Ioannina", Region = "GR", PostalCode = "45221", Country = "Greece", Phone = "6983" },
                new Customer { Id = Guid.Parse("80CA781B-113F-405F-A94B-DB46C151544D"), CompanyName = "Boura 3", ContactName = "George 3", Address = "Papanastasiou 3", City = "Ioannina", Region = "GR", PostalCode = "45221", Country = "Greece", Phone = "6983" },
                new Customer { Id = Guid.Parse("5db8e1b9-625e-4a1c-b1bf-851b993b5f88"), CompanyName = "Boura 4", ContactName = "George 4", Address = "Papanastasiou 4", City = "Ioannina", Region = "GR", PostalCode = "45221", Country = "Greece", Phone = "6983" },
                new Customer { Id = Guid.Parse("a6857dad-eb53-4f9c-a081-6a4d586fed49"), CompanyName = "Boura 5", ContactName = "George 5", Address = "Papanastasiou 5", City = "Ioannina", Region = "GR", PostalCode = "45221", Country = "Greece", Phone = "6983" },
                new Customer { Id = Guid.Parse("86b836d3-a77d-41f4-ac7e-961be0ab1967"), CompanyName = "Boura 6", ContactName = "George 6", Address = "Papanastasiou 6", City = "Ioannina", Region = "GR", PostalCode = "45221", Country = "Greece", Phone = "6983" },
                new Customer { Id = Guid.Parse("6b836d35-a77d-41f4-ac7e-961be0ab1963"), CompanyName = "Boura 7", ContactName = "George 7", Address = "Papanastasiou 7", City = "Ioannina", Region = "GR", PostalCode = "45221", Country = "Greece", Phone = "6983" }
            );
        }
    }
}
