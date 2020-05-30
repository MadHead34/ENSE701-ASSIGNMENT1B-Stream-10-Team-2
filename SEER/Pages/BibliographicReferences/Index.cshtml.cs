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
        public string SearchBenefit { get; set; } // The main benefit that a user wants to search for, should have some kind of token based search idk how hard that will be
        [BindProperty(SupportsGet = true)]
        public string SearchTitle { get; set; }
        public SelectList Sources { get; set; }
        public SelectList SEMethod { get; set; } /* TDD, BDD, pair programming, planning poker, daily standup meetings, story boards, user story mapping, continuous integration, retrospectives,
                                                    burn down charts, requirements prioritisation, verison control, code sharing */
        public SelectList SEPractice { get; set; } /* Scrum, Waterfall, Spiral, XP, Rational Unified Process, Crystal, Clean room, Feature Driven Development, Model Driven Development,
                                                      Valuse Driven Development, Product Driven Development, Agile */
        public SelectList ResearchMethod { get; set; } /* Case study, Field Observation, Experiment, Interview, Survey */
        public SelectList ResearchParticipants { get; set; } /* Undergraduate students, postgraduate students, practitioners */
        public SelectList ResearchResult { get; set; } /* Supports outcome, doesn't support outcome, inconclusive */
        [BindProperty(SupportsGet = true)]
        public string SearchSource { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchSEMethod { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchSEPractice { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchMethod { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchParticipants { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchResult { get; set; }
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

            // Use LINQ to get list of SE methods.
            IQueryable<string> methodQuery = from r in _context.BibliographicReference
                                             orderby r.SEMethod
                                             select r.SEMethod;

            // Use LINQ to get list of SE practices.
            IQueryable<string> practiceQuery = from r in _context.BibliographicReference
                                               orderby r.Practice
                                               select r.Practice;

            // Use LINQ to get list of research methods.
            IQueryable<string> researchQuery = from r in _context.BibliographicReference
                                               orderby r.Method
                                               select r.Method;

            // Use LINQ to get list of research participants.
            IQueryable<string> participantQuery = from r in _context.BibliographicReference
                                                  orderby r.Participant
                                                  select r.Participant;

            // Use LINQ to get a list of research outcomes.
            IQueryable<string> resultQuery = from r in _context.BibliographicReference
                                              orderby r.Result
                                              select r.Result;

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

            if (!string.IsNullOrEmpty(SearchSEMethod))
            {
                references = references.Where(x => x.Source == SearchSEMethod);
            }

            if (!string.IsNullOrEmpty(SearchSEPractice))
            {
                references = references.Where(x => x.Source == SearchSEPractice);
            }

            if (!string.IsNullOrEmpty(SearchMethod))
            {
                references = references.Where(x => x.Source == SearchMethod);
            }

            if (!string.IsNullOrEmpty(SearchParticipants))
            {
                references = references.Where(x => x.Source == SearchParticipants);
            }

            if (!string.IsNullOrEmpty(SearchResult))
            {
                references = references.Where(x => x.Source == SearchResult);
            }

            if (!string.IsNullOrEmpty(SearchAuthor))
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
            SEMethod = new SelectList(await methodQuery.Distinct().ToListAsync());
            SEPractice = new SelectList(await practiceQuery.Distinct().ToListAsync());
            ResearchMethod = new SelectList(await researchQuery.Distinct().ToListAsync());
            ResearchParticipants = new SelectList(await participantQuery.Distinct().ToListAsync());
            ResearchResult = new SelectList(await resultQuery.Distinct().ToListAsync());
            BibliographicReference = await references.ToListAsync();
        }
    }
}
