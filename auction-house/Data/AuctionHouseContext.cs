using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AuctionHouse.Models;

    public class AuctionHouseContext : DbContext
    {
        public AuctionHouseContext (DbContextOptions<AuctionHouseContext> options)
            : base(options)
        {
        }
        public DbSet<AuctionHouse.Models.Seller> Seller { get; set; } = default!;
        public DbSet<AuctionHouse.Models.Origin> Origin { get; set; } = default!;
        public DbSet<AuctionHouse.Models.Category> Category { get; set; } = default!;
        public DbSet<AuctionHouse.Models.AuctionEvent> AuctionEvent { get; set; } = default!;
        public DbSet<AuctionHouse.Models.Item> Item { get; set; } = default!;

    }
