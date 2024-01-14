using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AuctionHouse.Models;

namespace auction_house.Pages.Items
{
    public class CreateModel : PageModel
    {
        private readonly AuctionHouseContext _context;

        public CreateModel(AuctionHouseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AuctionEventId"] = new SelectList(_context.Set<AuctionEvent>(), "AuctionEventId", "Title");
            return Page();
        }

        [BindProperty]
        public Item Item { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Item == null || Item == null)
            {
                return Page();
            }

            _context.Item.Add(Item);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
