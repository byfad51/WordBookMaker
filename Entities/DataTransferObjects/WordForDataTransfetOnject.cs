namespace Entities.DataTransferObjects;

public record WordForDataTransfetOnject
{
    public int Id { get; set; }
    public String EnglishWord { get; set; }
    public String TurkishMean { get; set; }
}