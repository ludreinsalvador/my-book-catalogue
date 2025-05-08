using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBookCatalogue.Data;
using MyBookCatalogue.Model;

namespace MyBookCatalogue.Pages.Book
{
    public class CreateModel : PageModel
    {
        private readonly MyBookCatalogue.Data.MyBookCatalogueContext _context;

        public CreateModel(MyBookCatalogue.Data.MyBookCatalogueContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BookCatalogue BookCatalogue { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.BookCatalogue == null || BookCatalogue == null)
            {
                return Page();
            }

            _context.BookCatalogue.Add(BookCatalogue);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
