using System;
using System.ComponentModel.DataAnnotations;

namespace AuctionHouse.Models
{
    public class Category
    {
        public int ID { get; set; }

        [Required, MaxLength(200)]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Period { get; set; }

        public ICollection<Item>? Items { get; set; }
        public ICollection<Origin>? Origins { get; set; }


    }
}

