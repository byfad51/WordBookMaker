namespace Entities.DataTransferObjects;

public class WordResponseForDto
{
    public int WordId{ get; set; }

    public String EnglishWord{ get; set; }

    public String TurkishMean { get; set; }
    
    public int UserId { get; set; }
}