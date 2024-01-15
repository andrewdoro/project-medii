using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AuctionHouse.Models
{
    public class Origin
    {
        public int ID { get; set; }

        [Required, MaxLength(200), DisplayName("Historical Place")]
        public string HistoricalPlace { get; set; }

        [DisplayName("Current Country")]
        public string CurrentCountry { get; set; }

        public int CategoryID { get; set; }

        public Category? Category { get; set; }
    }
}



