using System.ComponentModel.DataAnnotations;

namespace LibraryBooks.Models;

public class Book
{
	public int Id { get; set; }

	[Required]
	public string Title { get; set; } = string.Empty;

	[Required]
	public string Author { get; set; } = string.Empty;

	[Required]
	public string Genre { get; set; } = string.Empty;

	public bool IsAvailable { get; set; } = true;

}
