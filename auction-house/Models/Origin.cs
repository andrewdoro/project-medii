using System;
using System.ComponentModel.DataAnnotations;

namespace AuctionHouse.Models
{
    public class Origin
    {
        public int ID { get; set; }

        [Required, MaxLength(200)]
        public string HistoricalPlace { get; set; }

        public string CurrentCountry { get; set; }

    }
}



