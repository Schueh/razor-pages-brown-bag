using System.Linq;
using System.Threading.Tasks;
using Bookstore.Data;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.ViewComponents
{
    public class RecentBooks : ViewComponent
    {
        private readonly BookContext _bookContext;

        public RecentBooks(BookContext bookContext)
        {
            _bookContext = bookContext;
            
            // workaround for in-memory database
            _bookContext.Database.EnsureCreated();
        }

        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            var recentBooks = _bookContext.Books
                                .OrderByDescending(x => x.ReleaseDate)
                                .Take(count);

            return View(recentBooks);
        }
    }
}