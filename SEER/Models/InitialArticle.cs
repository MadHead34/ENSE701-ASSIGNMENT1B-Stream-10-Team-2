using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEER.Models
{
    public class InitialArticle
    {
        public int ID { get; set; } // Primary Key
        [Required]
        [Display(Order = -1)]
        public string Title { get; set; }
        [Display(Order = 0)]
        [Required]
        public string Author { get; set; }
        [Display(Order = 0)]
        [Required]
        public string Source { get; set; } // This is the source of where the reference came from e.g. journal/web address for articles/web pages and publisher for books
        [Required]
        [Display(Prompt = "2020", Order = 0)]
        [Range(1970, 2020)]
        public int Year { get; set; }
        [Required]
        [Display(Order = 0)]
        [Url(ErrorMessage = "Enter a Url")]
        public string DOI { get; set; }
    }
}
