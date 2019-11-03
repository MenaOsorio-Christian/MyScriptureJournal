using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyScriptureJournal.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal.Models.MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournal.Models.MyScriptureJournalContext context)
        {
            _context = context;
        }

        //sort variables
        public string BookSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentKeyWord { get; set; }

        public IList<Scripture> Scripture { get; set;}


        public async Task OnGetAsync(string sortOrder, string searchString, string searchKeyW)
        {
            BookSort = String.IsNullOrEmpty(sortOrder) ? "book_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            CurrentFilter = searchString;
            CurrentKeyWord = searchKeyW;

            IQueryable<Scripture> scripturesIQ = from m in _context.Scripture
                             select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                scripturesIQ = scripturesIQ.Where(m => m.Book.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(searchKeyW))
            {
                scripturesIQ = scripturesIQ.Where(m => m.Note.Contains(searchKeyW));
            }


            switch (sortOrder)
            {
                case "book_desc":
                    scripturesIQ = scripturesIQ.OrderByDescending(m => m.Book);
                    break;
                case "Date":
                    scripturesIQ = scripturesIQ.OrderBy(m => m.EntryDate);
                    break;
                case "date_desc":
                    scripturesIQ = scripturesIQ.OrderByDescending(m => m.EntryDate);
                    break;
                default:
                    scripturesIQ = scripturesIQ.OrderBy(m => m.Book);
                    break;
            }


            Scripture = await scripturesIQ.AsNoTracking().ToListAsync();
           
        }
    }
}
