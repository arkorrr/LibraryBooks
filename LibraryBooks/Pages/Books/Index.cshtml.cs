using LibraryBooks.Data;
using LibraryBooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace LibraryBooks.Pages.Books
{
    public class IndexModel : PageModel
    {
		public IEnumerable<Book> Books { get; private set; } = new List<Book>();

		[BindProperty(SupportsGet = true)]
		public string CurrentFilter { get; set; } = string.Empty;

		public void OnGet()
        {
            if (!string.IsNullOrWhiteSpace(CurrentFilter))
            {
                Books = BookStore.Books
                    .Where(b =>
                        b.Title.Contains(CurrentFilter, StringComparison.OrdinalIgnoreCase) ||
                        b.Author.Contains(CurrentFilter, StringComparison.OrdinalIgnoreCase) ||
                        b.Genre.Contains(CurrentFilter, StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                Books = BookStore.Books;
            }
        }

    }
}
