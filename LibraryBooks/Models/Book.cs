using LibraryBooks.Resources;
using System.ComponentModel.DataAnnotations;
using System.Resources;

namespace LibraryBooks.Models;

public class Book
{
	public int Id { get; set; }

    [Required(ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "Title")]
    public string Title { get; set; } = string.Empty;


    [Required(ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "Author")]
    public string Author { get; set; } = string.Empty;

    [Required(ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "Genre")]
    public string Genre { get; set; } = string.Empty;

	public bool IsAvailable { get; set; } = true;

}
