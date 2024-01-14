
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
namespace AuctionHouse.Models
{

    public class User
    {
        public int UserId { get; set; }

        [Required, MaxLength(100)]
        public string Username { get; set; }

        [Required, EmailAddress, MaxLength(255)]
        public string Email { get; set; }

        // Navigation property for bids
        public List<Bid> Bids { get; set; }

        // Navigation property for auction events
        public List<AuctionEvent> AuctionEvents { get; set; }
    }
}

