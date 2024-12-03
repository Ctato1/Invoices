using System.ComponentModel.DataAnnotations;

namespace Invoice.API.DTOs
{
    public class AddressDTO
    {
        [Key]
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
    }
}
