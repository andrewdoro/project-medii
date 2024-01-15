using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AuctionHouse.Models;

namespace auction_house.Pages.Origins
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
        ViewData["CategoryID"] = new SelectList(_context.Category, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public Origin Origin { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Origin == null || Origin == null)
            {
                return Page();
            }

            _context.Origin.Add(Origin);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
