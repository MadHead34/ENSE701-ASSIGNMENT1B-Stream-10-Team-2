using BibtexLibrary;
using LexicalAnalyzer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SEER.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEER.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new SEERContext(
                serviceProvider.GetRequiredService<DbContextOptions<SEERContext>>());
            // Look for any bibliographic references.
            if (context.BibliographicReference.Any())
            {
                return; // DB has been seeded
            }

            try
            {
                using StreamReader sr = new StreamReader("input.txt", Encoding.Default);
                BibtexFile file = BibtexImporter.FromString(sr.ReadToEnd().Replace("'", "", StringComparison.Ordinal));

                foreach (BibtexEntry entry in file.Entries)
                {
                    context.BibliographicReference.Add(
                        new BibliographicReference
                        {
                            Title = entry.Tags["title"],
                            Author = entry.Tags["author"],
                            Year = int.Parse(entry.Tags["year"]),
                            Source = entry.Tags["journal"],
                            Volume = int.Parse(entry.Tags["volume"]),
                            Number = int.Parse(entry.Tags["number"]),
                            PageNumbers = entry.Tags["pages"],
                            DOI = entry.Tags["doi"]
                        }
                    );
                }
                context.SaveChanges();
            }
            catch (MatchException ex)
            {

            }
        }
    }
}
