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
    public class AcceptModel : PageModel
    {
        private readonly SEER.Data.SEERContext _context;

        public AcceptModel(SEER.Data.SEERContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            InitialArticle = await _context.InitialArticle.FindAsync(id);

            if (InitialArticle != null)
            {
                _context.AcceptedArticle.Add(
                    new AcceptedArticle
                    {
                        Title = InitialArticle.Title,
                        Author = InitialArticle.Author,
                        Source = InitialArticle.Source,
                        Year = InitialArticle.Year,
                        DOI = InitialArticle.DOI
                    });
                _context.InitialArticle.Remove(InitialArticle);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Moderate");
        }
    }
}
