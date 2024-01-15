using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AuctionHouse.Models;

namespace auction_house.Pages.Origins
{
    public class IndexModel : PageModel
    {
        private readonly AuctionHouseContext _context;

        public IndexModel(AuctionHouseContext context)
        {
            _context = context;
        }

        public IList<Origin> Origin { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Origin != null)
            {
                Origin = await _context.Origin
                .Include(o => o.Category).ToListAsync();
            }
        }
    }
}
