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

		public void OnGet()
        {
            Books = BookStore.Books;
        }


    }
}
