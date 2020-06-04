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
    public class AdminModel : PageModel
    {
        private readonly SEER.Data.SEERContext _context;

        public AdminModel(SEER.Data.SEERContext context)
        {
            _context = context;
        }

        public IList<BibliographicReference> BibliographicReference { get; set; }

        public async Task OnGetAsync()
        {
            var references = from r in _context.BibliographicReference
                             select r;

            BibliographicReference = await references.ToListAsync();
        }
    }
}
