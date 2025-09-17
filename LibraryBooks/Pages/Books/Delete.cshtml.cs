using LibraryBooks.Data;
using LibraryBooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryBooks.Pages.Books
{
    public class DeleteModel : PageModel
    {
        public Book? Book { get; private set; }

        public void OnGet()
        {
           
        }

        public IActionResult OnPost(int id)
        {
            var book = BookStore.Books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                BookStore.Books.Remove(book);
                return RedirectToPage("./Index");
            }
            return NotFound();
        }
    }
}
