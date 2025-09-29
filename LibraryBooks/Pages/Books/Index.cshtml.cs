using LibraryBooks.Data;
using LibraryBooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;

namespace LibraryBooks.Pages.Books
{
    public class IndexModel : PageModel
    {
		public IEnumerable<Book> Books { get; private set; } = new List<Book>();

		[BindProperty(SupportsGet = true)]
		public string CurrentFilter { get; set; } = string.Empty;

        private readonly IMemoryCache _cache;
        public IndexModel(IMemoryCache cache) => _cache = cache;

        public void OnGet()
        {
            var filter = (CurrentFilter ?? string.Empty).Trim();
            var cacheKey = string.IsNullOrEmpty(filter) ? "books:all" : $"books:filter:{filter.ToLowerInvariant()}";
            if (!_cache.TryGetValue(cacheKey, out IEnumerable<Book> cachedBooks))
            {
                if (!string.IsNullOrWhiteSpace(filter))
                {
                    cachedBooks = BookStore.Books
                        .Where(b =>
                            b.Title.Contains(filter, StringComparison.OrdinalIgnoreCase) ||
                            b.Author.Contains(filter, StringComparison.OrdinalIgnoreCase) ||
                            b.Genre.Contains(filter, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                }
                else
                {
                    cachedBooks = BookStore.Books.ToList();
                }

                var cacheOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
                    SlidingExpiration = TimeSpan.FromMinutes(1),
                    Priority = CacheItemPriority.Normal
                };

                _cache.Set(cacheKey, cachedBooks, cacheOptions); 
            }

            Books = cachedBooks;
        }

    }
}
