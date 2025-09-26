using LibraryBooks.Data;
using LibraryBooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;

namespace LibraryBooks.Pages.Books
{
    public class DeleteModel : PageModel
    {
        public Book? Book { get; private set; }

        private readonly IMemoryCache _cache;
        public DeleteModel(IMemoryCache cache) => _cache = cache;

        public void OnGet(int id)
        {
            Book = BookStore.Books.FirstOrDefault(x => x.Id == id);
            return;
        }

        public IActionResult OnPost(int id)
        {
            var bookKey = $"book:{id}";
           
            var book = BookStore.Books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                BookStore.Books.Remove(book);
                _cache.Remove(bookKey);
                _cache.Remove("books:all");
                return RedirectToPage("./Index");
            }
            return NotFound();
        }
    }
}
