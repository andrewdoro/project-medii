using System;
using System.ComponentModel.DataAnnotations;

namespace AuctionHouse.Models
{
    public class AuctionEvent
    {
        public int AuctionEventId { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        // Navigation property for items
        public List<Item> Items { get; set; }

        // Foreign key for User
        public int UserId { get; set; }

        // Navigation property for User
        public User User { get; set; }
    }
}

