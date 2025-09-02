using System.Text.Json;
using Markdig;
using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
[ApiController]
public class NoteController : ControllerBase
{
    private readonly INoteRepository _noteRepository;

    public NoteController(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }

    [HttpGet("all")]
    public async Task<IActionResult> AllNoteView()
    {
        var notes = await _noteRepository.GetAllNotesAsync();
        return Ok(notes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetNoteById(int id)
    {
        var note = await _noteRepository.GetNoteByIdAsync(id);
        if (note == null) return NotFound();
        return Ok(note);
    }

    [HttpGet("markdown/{id}")]
    public async Task<IActionResult> GetNoteMarkdown(int id)
    {
        var note = await _noteRepository.GetNoteByIdAsync(id);
        if (note == null) return NotFound();
        var markdown = _noteRepository.GetMarkDown(note.Content);
        return Ok(new { html = markdown });
    }

    [HttpGet("checker/{id}")]
    public async Task<IActionResult> CheckNoteGrammar(int id)
    {
        var note = await _noteRepository.GetNoteByIdAsync(id);
        if (note == null) return NotFound();

        var result = await _noteRepository.CheckerAsync(note.Content);
        if (string.IsNullOrEmpty(result)) return NotFound();
        return Ok(JsonDocument.Parse(result));
    }

    [HttpPost]
    public async Task<IActionResult> CreateNote([FromBody] CreateNoteDto noteDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var note = noteDto.ToCreateNote();
        var result = await _noteRepository.CreateNoteAsync(note);
        if (!result) return StatusCode(500);

        return Ok("Note created successfully");
    }
    [HttpPost("Upload-file-Markdown")]
    public async Task<IActionResult> UploadFileMarkdown(IFormFile file)
    {
        if (file == null || file.Length == 0) return BadRequest("No file uploaded.");

        string content;

        var reader = new StreamReader(file.OpenReadStream());

        content = await reader.ReadToEndAsync();

        var html = _noteRepository.GetMarkDown(content);

        return Content(html, "text/html");
    }

    [HttpPost("Upload-file-Checker")]
    public async Task<IActionResult> UploadFileChecker(IFormFile file)
    {
        if (file == null || file.Length == 0) return BadRequest("No file uploaded.");

        string content;

        var reader = new StreamReader(file.OpenReadStream());

        content = await reader.ReadToEndAsync();

        var result = await _noteRepository.CheckerAsync(content);
        if (string.IsNullOrEmpty(result)) return NotFound();

        return Ok(JsonDocument.Parse(result));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateNote(int id, [FromBody] UpdateNoteDto noteDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var existingNote = await _noteRepository.GetNoteByIdAsync(id);
        if (existingNote == null) return NotFound();

        var result = await _noteRepository.UpdateNoteAsync(id, noteDto);
        if (!result) return StatusCode(500);

        return Ok("Note updated successfully");
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNote(int id)
    {
        var existingNote = await _noteRepository.GetNoteByIdAsync(id);
        if (existingNote == null) return NotFound();

        var result = await _noteRepository.DeleteNoteAsync(id);
        if (!result) return StatusCode(500);

        return Ok("Note deleted successfully");
    }

}