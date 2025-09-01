public static class NoteMapping
{
    public static Note ToCreateNote(this CreateNoteDto dto)
    {
        return new Note
        {
            Title = dto.Title,
            Content = dto.Content,
            CreatedAt = DateTime.UtcNow
        };
    }
    public static ViewNoteDto ToViewNoteDto(this Note note)
    {
        return new ViewNoteDto
        {
            Id = note.Id,
            Title = note.Title,
            Content = note.Content,
            CreatedAt = note.CreatedAt
        };
    }
    public static Note ToNote(this ViewNoteDto dto)
    {
        return new Note
        {
            Id = dto.Id,
            Title = dto.Title,
            Content = dto.Content,
            CreatedAt = dto.CreatedAt
        };
    }
    public static ViewAllNotesDto ToViewAllNotesDto(this Note note)
    {
        return new ViewAllNotesDto
        {
            Id = note.Id,
            Title = note.Title,
            CreatedAt = note.CreatedAt
        };
    }
    public static Note ToUpdateNote(this UpdateNoteDto dto , Note note)
    {
        note.Title = dto.Title;
        note.Content = dto.Content;
        return note;
    }
}