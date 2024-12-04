using Invoice.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Invoice.API.DBContext
{
    public class InvoiceContext : DbContext
    {
        public InvoiceContext(DbContextOptions<InvoiceContext> options) : base(options) { }

        public DbSet<InvoiceEntity> Invoices { get; set; }

    }
}

