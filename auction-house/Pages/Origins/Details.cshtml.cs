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
    public class DetailsModel : PageModel
    {
        private readonly AuctionHouseContext _context;

        public DetailsModel(AuctionHouseContext context)
        {
            _context = context;
        }

      public Origin Origin { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Origin == null)
            {
                return NotFound();
            }

            var origin = await _context.Origin.FirstOrDefaultAsync(m => m.ID == id);
            if (origin == null)
            {
                return NotFound();
            }
            else 
            {
                Origin = origin;
            }
            return Page();
        }
    }
}
