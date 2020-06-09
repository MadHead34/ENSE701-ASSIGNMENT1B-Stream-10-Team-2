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
    public class ModerateEditModel : PageModel
    {
        private readonly SEER.Data.SEERContext _context;

        public ModerateEditModel(SEER.Data.SEERContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InitialArticle InitialArticle { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            InitialArticle = await _context.InitialArticle.FirstOrDefaultAsync(m => m.ID == id);

            if (InitialArticle == null)
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

            _context.Attach(InitialArticle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InitialArticleExists(InitialArticle.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Moderate");
        }

        private bool InitialArticleExists(int id)
        {
            return _context.InitialArticle.Any(e => e.ID == id);
        }
    }
}
