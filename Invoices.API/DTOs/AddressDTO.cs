using System.ComponentModel.DataAnnotations;

namespace Invoice.API.DTOs
{
    public class AddressDTO
    {
        [Required]
        public required string Street { get; set; }
        [Required]
        public required string City { get; set; }
        [Required]
        public required string PostCode { get; set; }
        [Required]
        public required string Country { get; set; }
    }
}
