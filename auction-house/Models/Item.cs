using System;
using System.ComponentModel.DataAnnotations;

namespace AuctionHouse.Models
{

    public class Item
    {
        public int ItemId { get; set; }



        [Required, MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(0, double.MaxValue)]
        public decimal StartingPrice { get; set; }

        // Foreign key for AuctionEvent
        public int AuctionEventId { get; set; }

        // Navigation property for AuctionEvent
        public AuctionEvent AuctionEvent { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
    }
}

