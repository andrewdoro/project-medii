using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AuctionHouse.Models
{

    public class Item
    {
        public int ID { get; set; }

        [Required, MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(0, double.MaxValue),DisplayName("Starting Price"),DisplayFormat(DataFormatString ="{0:C}")]
        public decimal StartingPrice { get; set; }

        [ DisplayName("Auction Event")]

        public int AuctionEventID { get; set; }

        // Navigation property for AuctionEvent
        public AuctionEvent? AuctionEvent { get; set; }

        [DataType(DataType.Date),DisplayName("Start Date")]
        public DateTime StartDate { get; set; }

        [DisplayName("Seller")]
        public int SellerID { get; set; }

        // Navigation property for User
        public Seller? Seller { get; set; }

        [DisplayName("Category")]
        public int CategoryID { get; set; }

        public Category? Category { get; set; }

        [DisplayName("Origin")]
        public int OriginID { get; set; }

        public Origin? Origin { get; set; }

    }
}

