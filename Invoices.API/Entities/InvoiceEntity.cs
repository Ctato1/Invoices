using System.ComponentModel.DataAnnotations;

namespace Invoice.API.Entities
{
    public class InvoiceEntity
    {
        [Key]
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime PaymentDue { get; set; }
        public string Description { get; set; }
        public int PaymentTerms { get; set; }
        public string ClientName { get; set; }
        public string ClientEmail { get; set; }
        public string Status { get; set; } = "pending";
        public Address SenderAddress { get; set; }
        public Address ClientAddress { get; set; }
        public ICollection<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();
        public double Total { get; set; }

        public int SenderAddressId { get; set; }
        public int ClientAddressId { get; set; }

        // Constructor to ensure proper initialization
        public InvoiceEntity()
        {
            CreatedAt = DateTime.Now;  // Set CreatedAt to current date on instantiation
            PaymentDue = DateTime.Now.AddDays(30);  // Default PaymentDue to 30 days after CreatedAt (or you can calculate based on PaymentTerms)
        }
    }
}
