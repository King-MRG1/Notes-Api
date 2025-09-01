using Microsoft.EntityFrameworkCore;
using Markdig;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using Azure;

public class NoteRepository : INoteRepository
{
    private readonly NoteContext _context;

    public NoteRepository(NoteContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateNoteAsync(Note note)
    {
        try
        {
            await _context.Notes.AddAsync(note);
            return await _context.SaveChangesAsync() > 0;
        }
        catch (Exception ex)
        {
            // Log the exception if you have logging configured
            Console.WriteLine($"Error in CreateNoteAsync: {ex.Message}");
            return false;
        }
    }

    public async Task<bool> DeleteNoteAsync(int id)
    {
        try
        {
            var note = await _context.Notes.FindAsync(id);
            if (note == null) return false;
            _context.Notes.Remove(note);
            return await _context.SaveChangesAsync() > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in DeleteNoteAsync: {ex.Message}");
            return false;
        }
    }

    public async Task<List<ViewAllNotesDto>> GetAllNotesAsync()
    {
        try
        {
            return await _context.Notes.Select(t => t.ToViewAllNotesDto()).ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in GetAllNotesAsync: {ex.Message}");
            return new List<ViewAllNotesDto>();
        }
    }

    public async Task<ViewNoteDto?> GetNoteByIdAsync(int id)
    {
        try
        {
            var note = await _context.Notes.FirstOrDefaultAsync(t => t.Id == id);
            return note?.ToViewNoteDto();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in GetNoteByIdAsync: {ex.Message}");
            return null;
        }
    }

    public async Task<bool> UpdateNoteAsync(int id, UpdateNoteDto noteDto)
    {
        try
        {
            var existingNote = await _context.Notes.FindAsync(id);
            if (existingNote == null) return false;

            existingNote.Title = noteDto.Title;
            existingNote.Content = noteDto.Content;

            return await _context.SaveChangesAsync() > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in UpdateNoteAsync: {ex.Message}");
            return false;
        }
    }

    public async Task<string> GetMarkDownAsync(int id)
    {
        try
        {
            var note = await _context.Notes.FindAsync(id);
            if (note == null) return string.Empty;
            string html = Markdown.ToHtml(note.Content);
            return html;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in GetMarkDownAsync: {ex.Message}");
            return string.Empty;
        }
    }

    public async Task<string> CheckerAsync(int id)
    {
        try
        {
            var note = await _context.Notes.FindAsync(id);
            if (note == null) return "";

            var bodyFormat = new FormUrlEncodedContent(new Dictionary<string, string>{
            {"text",note.Content.ToLower() },
            {"language","en-US" }
        });

            using var client = new HttpClient();
            var response = await client.PostAsync("https://api.languagetool.org/v2/check", bodyFormat);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return $"Error: {response.StatusCode} - {errorContent}";
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"HTTP Error in CheckerAsync: {ex.Message}");
            return $"HTTP Error: {ex.Message}";
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"JSON Error in CheckerAsync: {ex.Message}");
            return $"JSON Error: {ex.Message}";
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in CheckerAsync: {ex.Message}");
            return $"Error: {ex.Message}";
        }
    }
}