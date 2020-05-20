using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SEER.Data;
using SEER.Models;

namespace SEER
{
    public class DeleteModel : PageModel
    {
        private readonly SEER.Data.SEERContext _context;

        public DeleteModel(SEER.Data.SEERContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BibliographicReference BibliographicReference { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BibliographicReference = await _context.BibliographicReference.FirstOrDefaultAsync(m => m.ID == id);

            if (BibliographicReference == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BibliographicReference = await _context.BibliographicReference.FindAsync(id);

            if (BibliographicReference != null)
            {
                _context.BibliographicReference.Remove(BibliographicReference);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
