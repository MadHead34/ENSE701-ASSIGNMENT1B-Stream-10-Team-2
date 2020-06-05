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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AcceptedArticle = await _context.AcceptedArticle.FindAsync(id);

            if (AcceptedArticle != null)
            {
                _context.BibliographicReference.Add(new BibliographicReference
                {
                    Title = AcceptedArticle.Title,
                    Author = AcceptedArticle.Author,
                    Source = AcceptedArticle.Source,
                    Year = AcceptedArticle.Year,
                    DOI = AcceptedArticle.DOI,
                    SEMethod = AcceptedArticle.SEMethod,
                    Practice = AcceptedArticle.Practice,
                    Method = AcceptedArticle.Method,
                    Participant = AcceptedArticle.Participant,
                    Result = AcceptedArticle.Result
                });
                _context.AcceptedArticle.Remove(AcceptedArticle);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
