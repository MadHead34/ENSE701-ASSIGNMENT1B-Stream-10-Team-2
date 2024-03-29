﻿using System;
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

        public DbSet<SEER.Models.AcceptedArticle> AcceptedArticle { get; set; }

        public DbSet<SEER.Models.InitialArticle> InitialArticle { get; set; }

        public DbSet<SEER.Models.RejectedArticle> RejectedArticle { get; set; }
    }
}
