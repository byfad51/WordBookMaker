using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace UserSaver;

[ApiController]
[Route("api/words")]
public class WordController:ControllerBase
{
    private readonly IServiceManager _service;

    public WordController(IServiceManager service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> AddOneWordWithId([FromBody] Word word)
    {
        await _service.Words.CreateOneWord(word);
        return Ok(word);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllWordsPaged([FromQuery] WordParameters wordParameters)
    {
        return Ok(await _service.Words.GetAllWords(wordParameters,false));
    }
    
    [HttpGet("/details")]
    public async Task<IActionResult> GetAllWordsDetailedPaged([FromQuery] WordParameters wordParameters)
    {
        return Ok(await _service.Words.GetAllWordsDetailed(wordParameters,false));
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetOneWordById([FromRoute(Name = "id")]int id)
    {
     return Ok(await _service.Words.GetOneWordById(id, false));
    }
    
    
    [HttpGet("details/{id:int}")]
    
    public async Task<IActionResult> GetOneWordWithNotesById([FromRoute(Name = "id")]int id)
    {
        return Ok(await _service.Words.GetOneWordWithNotesById(id, false));
    }
}