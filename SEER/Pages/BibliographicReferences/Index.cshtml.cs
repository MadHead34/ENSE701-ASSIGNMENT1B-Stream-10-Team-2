﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly SEER.Data.SEERContext _context;

        public IndexModel(SEER.Data.SEERContext context)
        {
            _context = context;
        }

        public IList<BibliographicReference> BibliographicReference { get;set; }

        public async Task OnGetAsync()
        {
            BibliographicReference = await _context.BibliographicReference.ToListAsync();
        }
    }
}
