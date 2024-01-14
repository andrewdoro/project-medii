using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AuctionHouse.Models;

namespace auction_house.Pages.Items
{
    public class IndexModel : PageModel
    {
        private readonly AuctionHouseContext _context;

        public IndexModel(AuctionHouseContext context)
        {
            _context = context;
        }

        public IList<Item> Item { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Item != null)
            {
                Item = await _context.Item
                .Include(i => i.AuctionEvent).ToListAsync();
            }
        }
    }
}
