using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentations.ActionFilters;
using Services.Contracts;

namespace UserSaver;

//[Authorize]
[ApiController]
[Route("/api/wordnotes")]
[ServiceFilter(typeof(LogFilterAttribute))]

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
    //[ServiceFilter(typeof(ValidationFilterAttribute))]

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
    [HttpDelete]
   
    public IActionResult DeleteOneWordNote(WordNote wordNote)
    {
        _service.WordNotes.DeleteOneWordNote(wordNote);
        return NoContent();
    }
    [HttpPut]
    public async Task<IActionResult> UpdateOneWordNote(WordNote wordNote)
    {
        var entity =await  _service.WordNotes.GetOneWordNoteById(wordNote.WordNoteId,false);
        if (wordNote.WordNoteId != entity.WordNoteId)
            throw new WordNoteBadUpdateRequestException(wordNote.WordId);
        await _service.WordNotes.UpdateOneWordNote(wordNote, false);
        return Ok(wordNote);
    }

}