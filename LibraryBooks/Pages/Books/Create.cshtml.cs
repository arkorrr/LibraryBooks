using LibraryBooks.Data;
using LibraryBooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;

namespace LibraryBooks.Pages.Books
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Book? Input { get; set; }

        private readonly IMemoryCache _cache;
        public CreateModel(IMemoryCache cache) => _cache = cache;

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            if(Input != null)
            {
                var newId = BookStore.Books.Any() ? BookStore.Books.Max(b => b.Id) + 1 : 1;

                var bookKey = $"book:{newId}";
                

				Input.Id = newId;
				BookStore.Books.Add(Input);
                _cache.Set(bookKey, Input);
                _cache.Remove("books:all");
                return RedirectToPage("./Index");
			}
            else
            {
                return Page(); 
            }
        }
    }
}
