using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEER.Models
{
    public class BibliographicReference
    {
        public int ID { get; set; } // Primary Key
        public int Year { get; set; }
        public int Number { get; set; } // Not sure what this is, it seems to follow the volume in APA so something to do with editions?
        public int Volume { get; set; } // This is probably only meaningful for journal articles that have volumes? Possibly books if there are multiple editions? I don't know how APA handles this
        public string Title { get; set; }
        public string Author { get; set; }
        public string Source { get; set; } // This is the source of where the reference came from e.g. journal/web address for articles/web pages and publisher for books
        public string DOI { get; set; }
        public string PageNumbers { get; set; }
    }
}
