using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SEER.Data;
using SEER.Models;

namespace SEER
{
    public class SearchModel : PageModel
    {
        private readonly SEER.Data.SEERContext _context;

        public SearchModel(SEER.Data.SEERContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BibliographicReference BibliographicReference { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BibliographicReference.Add(BibliographicReference);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
