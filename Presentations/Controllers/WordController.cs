using System.Text.Json;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentations.ActionFilters;
using Services.Contracts;

namespace UserSaver;
//[Authorize]
[ApiController]
[Route("api/words")]
[ServiceFilter(typeof(LogFilterAttribute))]


public class WordController : ControllerBase
{
    private readonly IServiceManager _service;

    public WordController(IServiceManager service)
    {
        _service = service;
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
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
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteOneWord([FromRoute(Name = "id")]int id)
    {
        await _service.Words.DeleteOneWord(id);
        return NoContent();
    }
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateOneWord([FromRoute(Name = "id")]int id, [FromBody]WordForDto wordForDto)
    {
        var entity =await _service.Words.GetOneWordById(id,false);
        if (wordForDto.WordId != entity.WordId)
            throw new WordBadUpdateRequestException(wordForDto.WordId);
        await _service.Words.UpdateOneWord(id, wordForDto, false);
        return Ok(wordForDto);
    }

    
}