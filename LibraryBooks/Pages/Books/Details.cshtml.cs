using LibraryBooks.Data;
using LibraryBooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace LibraryBooks.Pages.Books
{
    public class DetailsModel : PageModel
    {
        public Book? Book { get; private set; }

        public IActionResult OnGet(int id)
        {
            Book = BookStore.Books.FirstOrDefault(b => b.Id == id);
			if (Book == null)
            {
				return NotFound();
			}
			return Page();
        }
    }
}
