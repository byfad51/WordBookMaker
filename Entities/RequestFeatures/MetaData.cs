namespace Entities.RequestFeatures;

public class MetaData
{
    public int CurrentPage { get; set; }
    public int TotalPage { get; set; }
    
    public int PageSize { get; set; }
    public int TotalSize { get; set; }

    public bool HasNextPage => CurrentPage < TotalPage;
    public bool HasPreviousPage => CurrentPage > 1;
    }

