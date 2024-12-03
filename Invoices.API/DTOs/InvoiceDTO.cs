using Invoice.API.Entities;
using System.ComponentModel.DataAnnotations;

namespace Invoice.API.DTOs
{
    public class InvoiceDTO
    {
        public string Id { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime PaymentDue { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int PaymentTerms { get; set; }
        [Required]
        public string ClientName { get; set; }
        [Required]
        public string ClientEmail { get; set; }
        public string Status { get; set; } = "pending";
        [Required]
        public Address SenderAddress { get; set; }
        [Required]
        public Address ClientAddress { get; set; }
        [Required]
        public List<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();
        [Required]
        public decimal Total { get; set; }
        public int SenderAddressId { get; set; }
        public int ClientAddressId { get; set; }
    }
}
