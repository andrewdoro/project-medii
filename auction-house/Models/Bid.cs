using System;
using System.ComponentModel.DataAnnotations;

namespace AuctionHouse.Models
{
   
    public class Bid
    {
        public int BidId { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Amount { get; set; }

        public DateTime BidTime { get; set; }

        // Foreign key for User
        public int UserId { get; set; }

        // Navigation property for User
        public User User { get; set; }

        // Foreign key for Item
        public int ItemId { get; set; }

        // Navigation property for Item
        public Item Item { get; set; }
    }
}

