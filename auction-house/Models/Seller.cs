
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace AuctionHouse.Models
{

    public class Seller
    {
        public int ID { get; set; }

        [Required, MaxLength(100)]
        public string Username { get; set; }

        [Required, EmailAddress, MaxLength(255)]
        public string Email { get; set; }

        // Navigation property for bids
        public List<Item>? Items { get; set; }

    }
}

