namespace mlt.api.Models;

public class RssItem : BaseModel
{
    public string? Title { get; set; }
    public string? Link { get; set; }
    public DateTime PubDate { get; set; }
    public string? Description { get; set; }
}