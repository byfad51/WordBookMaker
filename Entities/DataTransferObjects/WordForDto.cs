using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects;

public record WordForDto
{
    public int WordId { get; set; }
    [Required(ErrorMessage = "English word is needed to add a new word.")] 
    [MinLength(2,ErrorMessage = "Your word is needed to have least 2 length.")]
    public String EnglishWord { get; set; }
    
    [Required(ErrorMessage = "Turkish mean is needed to add a new word.")]
    [MinLength(2,ErrorMessage = "Your Turkish mean is needed to have least 2 length.")]
    public String TurkishMean { get; set; }
}