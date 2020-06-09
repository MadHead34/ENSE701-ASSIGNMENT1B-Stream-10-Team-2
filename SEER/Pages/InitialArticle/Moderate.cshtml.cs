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
    public class ModerateModel : PageModel
    {
        private readonly SEER.Data.SEERContext _context;

        public ModerateModel(SEER.Data.SEERContext context)
        {
            _context = context;
        }

        public IList<InitialArticle> InitialArticle { get;set; }

        public async Task OnGetAsync()
        {
            InitialArticle = await _context.InitialArticle.ToListAsync();
        }
    }
}
