using LibraryBooks.Data;
using LibraryBooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryBooks.Pages.Books
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Book? Input { get; set; }

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
				var newId = BookStore.Books.Max(b => b.Id) + 1;
				Input.Id = newId;
				BookStore.Books.Add(Input);
                return RedirectToPage("./Index");
			}
            else
            {
                return Page(); 
            }
        }
    }
}
