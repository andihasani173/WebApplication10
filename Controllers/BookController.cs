using Microsoft.AspNetCore.Mvc;
using MLB.Models;

namespace MLB.Controllers
{
    public class BookController : Controller
    {
        private static List<Book> _books = new List<Book>
        {
            new Book
            {
                Id = 1,
                Title = "Kronikë në Gur",
                Author = "Ismail Kadare",
                PublicationYear = 1971,
                ISBN = "978-99927-0-351-5",
                Genre = "Letërsi Shqiptare"
            },
            new Book
            {
                Id = 2,
                Title = "Në kërkim të kohës së humbur",
                Author = "Marcel Proust",
                PublicationYear = 1913,
                ISBN = "978-12345-678-90",
                Genre = "Letërsi e Huaj"
            }
        };

        public IActionResult Index(string searchTitle, string searchAuthor)
        {
            var books = _books.AsQueryable();

            if (!string.IsNullOrEmpty(searchTitle))
            {
                books = books.Where(b => b.Title.ToLower().Contains(searchTitle.ToLower()));
            }

            if (!string.IsNullOrEmpty(searchAuthor))
            {
                books = books.Where(b => b.Author.ToLower().Contains(searchAuthor.ToLower()));
            }

            return View(books.ToList());
        }
    }
}
