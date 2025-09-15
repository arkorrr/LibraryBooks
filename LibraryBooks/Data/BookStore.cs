using LibraryBooks.Models;

namespace LibraryBooks.Data;

public class BookStore
{
	public static List<Book> Books { get; } = new()
	{
		new Book { Id = 1, Title = "Кобзар", Author = "Тарас Шевченко", Genre = "Поезія" },
		new Book { Id = 2, Title = "Лісова пісня", Author = "Леся Українка", Genre = "Драма" },
		new Book { Id = 3, Title = "Захар Беркут", Author = "Іван Франко", Genre = "Історичний роман" }
	};
}
