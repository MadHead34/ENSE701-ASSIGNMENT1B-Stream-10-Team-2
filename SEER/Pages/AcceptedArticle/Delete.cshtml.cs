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
    public class AcceptArticleModel : PageModel
    {
        private readonly SEER.Data.SEERContext _context;

        public AcceptArticleModel(SEER.Data.SEERContext context)
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
                if (string.IsNullOrEmpty(AcceptedArticle.Title) || string.IsNullOrEmpty(AcceptedArticle.Author) || string.IsNullOrEmpty(AcceptedArticle.Source) ||
                    AcceptedArticle.Year < 1970 || AcceptedArticle.Year > 2020 || string.IsNullOrEmpty(AcceptedArticle.DOI) || string.IsNullOrEmpty(AcceptedArticle.SEMethod) ||
                    string.IsNullOrEmpty(AcceptedArticle.Practice) || string.IsNullOrEmpty(AcceptedArticle.Method) || string.IsNullOrEmpty(AcceptedArticle.Participant) ||
                    string.IsNullOrEmpty(AcceptedArticle.Result))
                    return RedirectToPage("./Failure");

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
