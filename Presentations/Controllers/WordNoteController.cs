using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace UserSaver;
[ApiController]
[Route("/api/wordnotes")]

public class WordNoteController : ControllerBase
{
    private readonly IServiceManager _service;

    public WordNoteController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet("word/{id:int}")]
    public async Task<IActionResult> GetAllWordNotesByWordId([FromRoute(Name = "id")]int wordId)
    {
       var entities = await _service.WordNotes.GetAllWordsByWordId(wordId, false);
       return Ok(entities);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOneWordNote(WordNote wordNote)
    {
        await _service.WordNotes.CreateOneWordNote(wordNote);
        return Ok(wordNote);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetOneWordById([FromRoute(Name = "id")]int id)
    {
        var entity =await _service.WordNotes.GetOneWordNoteById(id,false);
        return Ok(entity);
    }
}