namespace Entities.Models;

public class Word
{
    public int Id{ get; set; }

    private String EnglishWord{ get; set; }

    public String TurkishMean { get; set; }

    public ICollection<WordNote> Notes { get; set; }

    public int UserId { get; set; }
}