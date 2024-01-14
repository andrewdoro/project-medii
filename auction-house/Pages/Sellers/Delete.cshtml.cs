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
    public class DeleteModel : PageModel
    {
        private readonly AuctionHouseContext _context;

        public DeleteModel(AuctionHouseContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Seller Seller { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Seller == null)
            {
                return NotFound();
            }

            var seller = await _context.Seller.FirstOrDefaultAsync(m => m.ID == id);

            if (seller == null)
            {
                return NotFound();
            }
            else 
            {
                Seller = seller;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Seller == null)
            {
                return NotFound();
            }
            var seller = await _context.Seller.FindAsync(id);

            if (seller != null)
            {
                Seller = seller;
                _context.Seller.Remove(Seller);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
