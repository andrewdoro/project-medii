using System;
using System.ComponentModel.DataAnnotations;

namespace AuctionHouse.Models
{

    public class Item
    {
        public int ID { get; set; }

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

        // Foreign key for User
        public int SellerId { get; set; }

        // Navigation property for User
        public Seller Seller { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public Origin Origin { get; set; }

        public int OriginId { get; set; }
    }
}

