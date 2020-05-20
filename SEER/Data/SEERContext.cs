using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SEER.Models;

namespace SEER.Data
{
    public class SEERContext : DbContext
    {
        public SEERContext (DbContextOptions<SEERContext> options)
            : base(options)
        {
        }

        public DbSet<SEER.Models.BibliographicReference> BibliographicReference { get; set; }
    }
}
