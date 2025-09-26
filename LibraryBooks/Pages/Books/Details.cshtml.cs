using LibraryBooks.Data;
using LibraryBooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;


namespace LibraryBooks.Pages.Books
{
    public class DetailsModel : PageModel
    {
        public Book? Book { get; private set; }

        private readonly IMemoryCache _cache;
        public DetailsModel(IMemoryCache cache) => _cache = cache;

        public IActionResult OnGet(int id)
        {
            
            var cacheKey = $"book:{id}";
            if (!_cache.TryGetValue<Book?>(cacheKey, out var cachedBook))
            {
                var bookFromStore = BookStore.Books.FirstOrDefault(b => b.Id == id);
                if (bookFromStore == null)
                    return NotFound();

                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30),
                    SlidingExpiration = TimeSpan.FromMinutes(5),
                    Priority = CacheItemPriority.Normal,
                };

                _cache.Set(cacheKey, bookFromStore, cacheEntryOptions);
                cachedBook = bookFromStore;
            }

            Book = cachedBook;
            return Page();
        }
    }
}
