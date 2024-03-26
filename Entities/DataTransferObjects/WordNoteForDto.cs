using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects;

public class WordNoteForDto
{
    public int WordNoteId { get; set; }

    [Required(ErrorMessage = "Note sentence is needed.")]
    [MinLength(8,ErrorMessage = "Your note has least 8 ")]
    public String WordNoteSentence { get; set; }
    
    
    [Required(ErrorMessage = "Word id is needed.")]
    public int WordId { get; set; }
}