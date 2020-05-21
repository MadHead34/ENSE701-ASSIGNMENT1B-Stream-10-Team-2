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
    public class IndexModel : PageModel
    {
        private readonly SEER.Data.SEERContext _context;

        public IndexModel(SEER.Data.SEERContext context)
        {
            _context = context;
        }

        public IList<BibliographicReference> BibliographicReference { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTitle { get; set; }
        public SelectList Sources { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchSource { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchAuthor { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchDOI { get; set; }
        [BindProperty(SupportsGet = true)]
        public int SearchYearStart { get; set; }
        [BindProperty(SupportsGet = true)]
        public int SearchYearEnd { get; set; }
        public async Task OnGetAsync()
        {
            // Use LINQ to get list of sources.
            IQueryable<string> sourceQuery = from r in _context.BibliographicReference
                                             orderby r.Source
                                             select r.Source;

            var references = from r in _context.BibliographicReference
                            select r;

            if(!string.IsNullOrEmpty(SearchTitle))
            {
                references = references.Where(s => s.Title.Contains(SearchTitle));
            }

            if (!string.IsNullOrEmpty(SearchSource))
            {
                references = references.Where(x => x.Source == SearchSource);
            }

            if(!string.IsNullOrEmpty(SearchAuthor))
            {
                references = references.Where(s => s.Author.Contains(SearchAuthor));
            }

            if(!string.IsNullOrEmpty(SearchDOI))
            {
                references = references.Where(s => s.DOI.Contains(SearchDOI));
            }

            if(SearchYearStart >= 1970 && SearchYearStart <= 2020 && SearchYearEnd >= 1970 && SearchYearEnd <= 2020)
            {
                references = references.Where(s => s.Year >= SearchYearStart && s.Year <= SearchYearEnd);
            }

            Sources = new SelectList(await sourceQuery.Distinct().ToListAsync());
            BibliographicReference = await references.ToListAsync();
        }
    }
}
