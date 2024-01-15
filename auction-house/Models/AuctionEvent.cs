using System;
using System.ComponentModel.DataAnnotations;

namespace AuctionHouse.Models
{
    public class AuctionEvent
    {
        public int ID { get; set; }
        [Required, MaxLength(200)]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        // Navigation property for items
        public List<Item>? Items { get; set; }

   
    }
}

