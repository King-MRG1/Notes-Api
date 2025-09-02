public interface INoteRepository
{
    public Task<List<ViewAllNotesDto>> GetAllNotesAsync();
    public Task<ViewNoteDto?> GetNoteByIdAsync(int id);
    public Task<bool> CreateNoteAsync(Note note);
    public Task<bool> UpdateNoteAsync(int id, UpdateNoteDto noteDto);
    public Task<bool> DeleteNoteAsync(int id);
    public string GetMarkDown(string content);
    public Task<string> CheckerAsync(string content);
}