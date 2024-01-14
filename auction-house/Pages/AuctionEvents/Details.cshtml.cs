using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AuctionHouse.Models;

namespace auction_house.Pages.AuctionEvents
{
    public class DetailsModel : PageModel
    {
        private readonly AuctionHouseContext _context;

        public DetailsModel(AuctionHouseContext context)
        {
            _context = context;
        }

      public AuctionEvent AuctionEvent { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AuctionEvent == null)
            {
                return NotFound();
            }

            var auctionevent = await _context.AuctionEvent.FirstOrDefaultAsync(m => m.ID == id);
            if (auctionevent == null)
            {
                return NotFound();
            }
            else 
            {
                AuctionEvent = auctionevent;
            }
            return Page();
        }
    }
}
