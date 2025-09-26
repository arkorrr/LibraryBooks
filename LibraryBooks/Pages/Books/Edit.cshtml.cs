using LibraryBooks.Data;
using LibraryBooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;

namespace LibraryBooks.Pages.Books
{
    public class EditModel : PageModel
    {
		[BindProperty]
		public Book? Input { get; set; }

        private readonly IMemoryCache _cache;
        public EditModel(IMemoryCache cache) => _cache = cache;

        public void OnGet()
        {
           
        }

		public IActionResult OnPost(int id)
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}
			var book = BookStore.Books.FirstOrDefault(b => b.Id == id);
			if (book == null)
			{
				return NotFound();
			}

			var bookKey = $"book:{id}";

			book.Title = Input.Title;
			book.Author = Input.Author;
			book.Genre = Input.Genre;

			_cache.Set(bookKey, book);

			return RedirectToPage("./Index");
		}
	}
}
