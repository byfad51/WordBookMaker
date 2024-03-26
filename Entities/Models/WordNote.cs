using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Entities.Models;

public class WordNote
{
    public int WordNoteId { get; set; }
    
    public String WordNoteSentence { get; set; }
    
    public int WordId { get; set; }

}