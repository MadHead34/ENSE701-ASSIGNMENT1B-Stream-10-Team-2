using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SEER.Data;
using SEER.Models;

namespace SEER
{
    public class EditModel : PageModel
    {
        private readonly SEER.Data.SEERContext _context;

        public EditModel(SEER.Data.SEERContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BibliographicReference).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BibliographicReferenceExists(BibliographicReference.ID))
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

        private bool BibliographicReferenceExists(int id)
        {
            return _context.BibliographicReference.Any(e => e.ID == id);
        }
    }
}
