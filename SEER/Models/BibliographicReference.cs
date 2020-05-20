using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEER.Models
{
    public class BibliographicReference
    {
        public int ID { get; set; } // Primary Key
        [Required]
        [Display(Order = -1)]
        public string Title { get; set; }
        [Display(Order = 0)]
        [Required]
        public string Author { get; set; }
        [Display(Order = 0)]
        public string Source { get; set; } // This is the source of where the reference came from e.g. journal/web address for articles/web pages and publisher for books
        [Display(Prompt = "2020", Order = 0)]
        [Range(1970, 2020)]
        public int Year { get; set; }
        [Display(Order = 0)]
        public int Volume { get; set; } // This is probably only meaningful for journal articles that have volumes? Possibly books if there are multiple editions? I don't know how APA handles this
        [Display(Order = 0)]
        public int Number { get; set; } // Not sure what this is, it seems to follow the volume in APA so something to do with editions?
        [Display(Name = "Pages", Prompt = "100-200", Order = 0)]
        public string PageNumbers { get; set; }
        [Display(Order = 0)]
        [Url(ErrorMessage = "Enter a Url")]
        public string DOI { get; set; }
    }
}
