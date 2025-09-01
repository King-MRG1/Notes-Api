using System.ComponentModel.DataAnnotations;

public class CreateNoteDto
{
    [Required]
    public string Title { get; set; } = "";
    [Required]
    public string Content { get; set; } = "";
}
