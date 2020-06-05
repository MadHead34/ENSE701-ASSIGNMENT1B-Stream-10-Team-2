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
    public class AddModel : PageModel
    {
        private readonly SEER.Data.SEERContext _context;

        public AddModel(SEER.Data.SEERContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AcceptedArticle AcceptedArticle { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AcceptedArticle = await _context.AcceptedArticle.FirstOrDefaultAsync(m => m.ID == id);

            if (AcceptedArticle == null)
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

            _context.Attach(AcceptedArticle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcceptedArticleExists(AcceptedArticle.ID))
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

        private bool AcceptedArticleExists(int id)
        {
            return _context.AcceptedArticle.Any(e => e.ID == id);
        }
    }
}
