public interface INoteRepository
{
    public Task<List<ViewAllNotesDto>> GetAllNotesAsync();
    public Task<ViewNoteDto?> GetNoteByIdAsync(int id);
    public Task<bool> CreateNoteAsync(Note note);
    public Task<bool> UpdateNoteAsync(int id, UpdateNoteDto noteDto);
    public Task<bool> DeleteNoteAsync(int id);
    public Task<string> GetMarkDownAsync(int id);
    public Task<string> CheckerAsync(int id);
    
}