﻿using System.ComponentModel.DataAnnotations;

namespace Invoice.API.Entities
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public required string Street { get; set; }
        public required string City { get; set; }
        public required string PostCode { get; set; }
        public required string Country { get; set; }

    }
}
