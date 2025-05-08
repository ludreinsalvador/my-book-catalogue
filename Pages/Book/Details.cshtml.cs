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
    public class DetailsModel : PageModel
    {
        private readonly MyBookCatalogue.Data.MyBookCatalogueContext _context;

        public DetailsModel(MyBookCatalogue.Data.MyBookCatalogueContext context)
        {
            _context = context;
        }

      public BookCatalogue BookCatalogue { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BookCatalogue == null)
            {
                return NotFound();
            }

            var bookcatalogue = await _context.BookCatalogue.FirstOrDefaultAsync(m => m.ID == id);
            if (bookcatalogue == null)
            {
                return NotFound();
            }
            else 
            {
                BookCatalogue = bookcatalogue;
            }
            return Page();
        }
    }
}
