using System.ComponentModel.DataAnnotations;

namespace Invoice.API.DTOs
{
    public class ItemDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double Price { get; set; }
        public double Total => Quantity * Price;
    }
}
