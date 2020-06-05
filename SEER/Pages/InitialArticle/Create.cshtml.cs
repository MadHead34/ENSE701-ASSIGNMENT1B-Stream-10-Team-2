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
    public class SubmitModel : PageModel
    {
        private readonly SEER.Data.SEERContext _context;

        public SubmitModel(SEER.Data.SEERContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public InitialArticle InitialArticle { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.InitialArticle.Add(InitialArticle);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Success");
        }
    }
}
