using LibraryBooks.Data;
using LibraryBooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryBooks.Pages.Books
{
    public class EditModel : PageModel
    {
		[BindProperty]
		public Book? Input { get; set; }

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

			book.Title = Input.Title;
			book.Author = Input.Author;
			book.Genre = Input.Genre;

			return RedirectToPage("./Index");
		}
	}
}
