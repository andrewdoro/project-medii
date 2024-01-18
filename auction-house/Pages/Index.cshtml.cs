using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionHouse.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace auction_house.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AuctionHouseContext _context;

        public IndexModel(AuctionHouseContext context)
        {
            _context = context;
        }

        public IList<AuctionEvent> AuctionEvent { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var currentDate = DateTime.Now;

            if (_context.AuctionEvent != null)
            {
                AuctionEvent = await _context.AuctionEvent
                    .Where(a => a.StartTime <= currentDate && a.EndTime >= currentDate)
                    .Include(a => a.Items)
                    .ToListAsync();
            }
        }
    }
}
