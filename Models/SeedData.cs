using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MyScriptureJournal.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyScriptureJournalContext(
               serviceProvider.GetRequiredService<
                   DbContextOptions<MyScriptureJournalContext>>()))
            {
                // Look for any scriptures
                if (context.Scripture.Any())
                {
                    return; // DB has been seeded
                }

                context.Scripture.AddRange(
                new Scripture
                {
                    Book = "Alma",
                    Chapter = 35,
                    Verse = 37,
                    Note = "Learn wisdom in your youth",
                    EntryDate = DateTime.Parse("2019-31-10")
                },

                new Scripture
                {
                    Book = "Mormon",
                    Chapter = 10,
                    Verse = 15,
                    Note = "Mormon words to his son",
                    EntryDate = DateTime.Parse("2019-30-10")
                },

                   new Scripture
                   {
                       Book = "Alma",
                       Chapter = 45,
                       Verse = 37,
                       Note = "young man warriors",
                       EntryDate = DateTime.Parse("2019-27-10")
                   },

                new Scripture
                {
                    Book = "2 Nephi",
                    Chapter = 11,
                    Verse = 15,
                    Note = "I don't remeber the words",
                    EntryDate = DateTime.Parse("2019-13-10")
                }
            );
                context.SaveChanges();
            }
        }
    }
}
