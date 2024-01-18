using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AuctionHouse.Models
{
    public class AuctionEvent
    {
        public int ID { get; set; }
        [Required, MaxLength(200)]
        public string Title { get; set; }

        public string Description { get; set; }

        [DisplayName("Start Date"), DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime StartTime { get; set; }

        [DisplayName("End Date"), DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime EndTime { get; set; }

        // Navigation property for items
        public List<Item>? Items { get; set; }

   
    }
}

