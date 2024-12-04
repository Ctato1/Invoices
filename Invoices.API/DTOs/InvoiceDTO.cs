using Invoice.API.Entities;
using System.ComponentModel.DataAnnotations;

namespace Invoice.API.DTOs
{
    public class InvoiceDTO
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

        public AddressDTO SenderAddress { get; set; }
        public AddressDTO ClientAddress { get; set; }
        public List<ItemDTO> Items { get; set; }
        public double Total { get; set; } = 0;
    }

}
