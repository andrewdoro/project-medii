using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AuctionHouse.Models;

namespace auction_house.Pages.Items
{
    public class EditModel : PageModel
    {
        private readonly AuctionHouseContext _context;

        public EditModel(AuctionHouseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Item Item { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Item == null)
            {
                return NotFound();
            }

            var item =  await _context.Item.FirstOrDefaultAsync(m => m.ID == id);
            if (item == null)
            {
                return NotFound();
            }
            Item = item;
           ViewData["AuctionEventID"] = new SelectList(_context.AuctionEvent, "ID", "Title");
           ViewData["CategoryID"] = new SelectList(_context.Category, "ID", "Name");
           ViewData["OriginID"] = new SelectList(_context.Origin, "ID", "HistoricalPlace");
           ViewData["SellerID"] = new SelectList(_context.Seller, "ID", "Email");
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

            _context.Attach(Item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(Item.ID))
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

        private bool ItemExists(int id)
        {
          return (_context.Item?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
