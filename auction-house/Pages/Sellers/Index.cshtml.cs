using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AuctionHouse.Models;

namespace auction_house.Pages.Sellers
{
    public class IndexModel : PageModel
    {
        private readonly AuctionHouseContext _context;

        public IndexModel(AuctionHouseContext context)
        {
            _context = context;
        }

        public IList<Seller> Seller { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Seller != null)
            {
                Seller = await _context.Seller.ToListAsync();
            }
        }
    }
}
