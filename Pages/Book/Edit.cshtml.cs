using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBookCatalogue.Data;
using MyBookCatalogue.Model;

namespace MyBookCatalogue.Pages.Book
{
    public class EditModel : PageModel
    {
        private readonly MyBookCatalogueContext _context;

        public EditModel(MyBookCatalogueContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BookCatalogue BookCatalogue { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookcatalogue = await _context.BookCatalogue.FirstOrDefaultAsync(m => m.ID == id);
            if (bookcatalogue == null)
            {
                return NotFound();
            }

            BookCatalogue = bookcatalogue;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingBook = await _context.BookCatalogue.FindAsync(BookCatalogue.ID);
            if (existingBook == null)
            {
                return NotFound();
            }

            existingBook.Title = BookCatalogue.Title;
            existingBook.Author = BookCatalogue.Author;
            existingBook.ISBN = BookCatalogue.ISBN;
            existingBook.Publisher = BookCatalogue.Publisher;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return RedirectToPage("./Index");
        }
    }
}
