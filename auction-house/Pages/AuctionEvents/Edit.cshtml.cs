using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AuctionHouse.Models;

namespace auction_house.Pages.AuctionEvents
{
    public class EditModel : PageModel
    {
        private readonly AuctionHouseContext _context;

        public EditModel(AuctionHouseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AuctionEvent AuctionEvent { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AuctionEvent == null)
            {
                return NotFound();
            }

            var auctionevent =  await _context.AuctionEvent.FirstOrDefaultAsync(m => m.ID == id);
            if (auctionevent == null)
            {
                return NotFound();
            }
            AuctionEvent = auctionevent;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AuctionEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuctionEventExists(AuctionEvent.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AuctionEventExists(int id)
        {
          return (_context.AuctionEvent?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
