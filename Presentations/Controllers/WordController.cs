using System.Text.Json;
using Entities.DataTransferObjects;
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
    public async Task<IActionResult> AddOneWordWithId([FromBody] WordForDto wordForDto)
    {
        var entity = await _service.Words.CreateOneWord(wordForDto);
        return Ok(entity);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllWordsPaged([FromQuery] WordParameters wordParameters)
    {
        
        var result = await _service.Words.GetAllWords(wordParameters, false);
        Response.Headers.Add("X-Pagination", 
            JsonSerializer.Serialize(result.MetaData));
        return Ok(result);
    } 
    
    [HttpGet("details")]
    public async Task<IActionResult> GetAllWordsDetailedPaged([FromQuery] WordParameters wordParameters)
    {
        var result = await _service.Words.GetAllWordsDetailed(wordParameters, false);
        Response.Headers.Add("X-Pagination", 
            JsonSerializer.Serialize(result.MetaData));
        return Ok(result);
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