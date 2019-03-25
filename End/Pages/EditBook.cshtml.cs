using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Data;
using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookstore.Pages
{
    public class EditBookModel : PageModel
    {
        private readonly BookContext _bookContext;

        [BindProperty]
        public Book Book { get; set; }

        public EditBookModel(BookContext bookContext)
        {
            _bookContext = bookContext;

            // workaround for in-memory database
            _bookContext.Database.EnsureCreated();
        }

        public IActionResult OnGet(int id)
        {
            var book = _bookContext.Books.SingleOrDefault(x => x.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            Book = book;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _bookContext.Update(Book);
            await _bookContext.SaveChangesAsync();

            return RedirectToPage("Books");
        }
    }
}