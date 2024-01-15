using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AuctionHouse.Models;

namespace auction_house.Pages.Origins
{
    public class EditModel : PageModel
    {
        private readonly AuctionHouseContext _context;

        public EditModel(AuctionHouseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Origin Origin { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Origin == null)
            {
                return NotFound();
            }

            var origin =  await _context.Origin.FirstOrDefaultAsync(m => m.ID == id);
            if (origin == null)
            {
                return NotFound();
            }
            Origin = origin;
           ViewData["CategoryID"] = new SelectList(_context.Category, "ID", "Name");
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

            _context.Attach(Origin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OriginExists(Origin.ID))
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

        private bool OriginExists(int id)
        {
          return (_context.Origin?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
