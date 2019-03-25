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
    public class BooksModel : PageModel
    {
        private readonly BookContext _bookContext;

        public IEnumerable<Book> Books { get; set; }

        public BooksModel(BookContext bookContext)
        {
            _bookContext = bookContext;

            // workaround for in-memory database
            _bookContext.Database.EnsureCreated();
        }

        public void OnGet()
        {
            Books = _bookContext.Books.ToList();
        }

        public IActionResult OnPostDelete(int id)
        {
            var book = _bookContext.Books.SingleOrDefault(x => x.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            _bookContext.Remove(book);
            _bookContext.SaveChanges();

            return RedirectToPage("Books");
        }
    }
}