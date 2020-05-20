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
    public class DetailsModel : PageModel
    {
        private readonly SEER.Data.SEERContext _context;

        public DetailsModel(SEER.Data.SEERContext context)
        {
            _context = context;
        }

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
    }
}
