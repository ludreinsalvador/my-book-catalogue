using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBookCatalogue.Data;
using MyBookCatalogue.Model;

namespace MyBookCatalogue.Pages.Book
{
    public class IndexModel : PageModel
    {
        private readonly MyBookCatalogue.Data.MyBookCatalogueContext _context;

        public IndexModel(MyBookCatalogue.Data.MyBookCatalogueContext context)
        {
            _context = context;
        }

        public IList<BookCatalogue> BookCatalogue { get;set; } = default!;

        public async Task OnGetAsync(string searchString)
        {
            var books = from b in _context.BookCatalogue
                        select b;

            if (!string.IsNullOrEmpty(searchString))
            {
                books = books.Where(b => b.Title.Contains(searchString));
            }

            BookCatalogue = await books.ToListAsync();
        }
        
    }
}
