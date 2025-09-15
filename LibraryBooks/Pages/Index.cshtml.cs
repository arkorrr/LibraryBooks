using LibraryBooks.Data;
using LibraryBooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryBooks.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;


        public int TotalCount { get; private set; }

        public int AvailableCount { get; private set; }

        public int UnavailableCount { get; private set; }

        public IndexModel(ILogger<IndexModel> logger)
		{
			_logger = logger;	
		}

		public void OnGet()
		{
            var books = BookStore.Books;

            TotalCount = books.Count;
            AvailableCount = books.Count(b => b.IsAvailable);
            UnavailableCount = TotalCount - AvailableCount;

        }
	}
}
