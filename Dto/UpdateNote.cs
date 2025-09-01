using System.ComponentModel.DataAnnotations;

public class UpdateNoteDto
{
    [Required]
    public string Title { get; set; } = "";
    [Required]
    public string Content { get; set; } = "";
}