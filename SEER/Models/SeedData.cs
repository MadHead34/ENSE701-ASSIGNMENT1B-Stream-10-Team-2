using BibtexLibrary;
using LexicalAnalyzer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
            if (!context.BibliographicReference.Any())
            {
                try
                {
                    using StreamReader sr = new StreamReader("input.txt", Encoding.Default);
                    BibtexFile file = BibtexImporter.FromString(sr.ReadToEnd().Replace("'", "", StringComparison.Ordinal));

                    foreach (BibtexEntry entry in file.Entries)
                    {
                        string? title = null, author = null, journal = null, doi = null;
                        int? year = null;
                        foreach (KeyValuePair<string, string> pair in entry.Tags)
                        {
                            string replaced = pair.Value.Replace("{", "", StringComparison.Ordinal).Replace("}", "", StringComparison.Ordinal).Replace("\\", "", StringComparison.Ordinal);
                            switch (pair.Key)
                            {
                                case "title":
                                    title = replaced;
                                    break;
                                case "author":
                                    author = replaced;
                                    break;
                                case "journal":
                                case "publisher":
                                    journal = replaced;
                                    break;
                                case "doi":
                                    doi = replaced;
                                    break;
                                case "year":
                                    year = int.Parse(replaced);
                                    break;
                                default:
                                    Console.Error.WriteLine($"Unknown key {pair.Key} with value {pair.Value} in bibtex entry.");
                                    break;
                            }
                        }
                        context.BibliographicReference.Add(
                            new BibliographicReference
                            {
                            // TODO: Make these not show up on user side when unknown? Probably not able to do that here lol
                            Title = title == null ? "Unknown" : title,
                                Author = author == null ? "Unknown" : author,
                                Source = journal == null ? "Unknown" : journal,
                                DOI = doi == null ? "Unknown" : doi,
                                Year = year.GetValueOrDefault()
                            }
                        );
                    }
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    // THROW THOSE STINKY EXCEPTIONS AWAY
                    throw;
                }

                if(!context.AcceptedArticle.Any())
                {
                    try
                    {
                        context.AcceptedArticle.Add(
                            new AcceptedArticle
                            {
                                Title = "Template",
                                Author = "Template",
                                Source = "Template",
                                Year = 2020,
                                DOI = "Template",
                                SEMethod = "Template",
                                Practice = "Template",
                                Method = "Template",
                                Participant = "Template",
                                Result = "Template"
                            });
                        context.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                }
            }
        }
    }
}
