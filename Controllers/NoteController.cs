using System.Text.Json;
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
        var markdown = await _noteRepository.GetMarkDownAsync(id);
        if (string.IsNullOrEmpty(markdown)) return NotFound();
        return Ok(new { html = markdown });
    }

    [HttpGet("checker/{id}")]
    public async Task<IActionResult> CheckNoteGrammar(int id)
    {
        var result = await _noteRepository.CheckerAsync(id);
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