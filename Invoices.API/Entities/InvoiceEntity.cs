using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string Status { get; set; }

        public Address SenderAddress { get; set; }
        public Address ClientAddress { get; set; }
        public ICollection<Item> Items { get; set; }
        public double Total { get; set; }

    }
}
