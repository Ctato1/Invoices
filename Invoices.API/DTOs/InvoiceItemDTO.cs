using System.ComponentModel.DataAnnotations;

namespace Invoice.API.DTOs
{
    public class InvoiceItemDTO
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
    }
}
