namespace mlt.api.Models;

public class FreshRss : BaseModel
{
    public double RssId { get; set; }
    public int FeedId { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Html { get; set; }
    public string? Url { get; set; }
    public bool IsSaved { get; set; }
    public bool IsRead { get; set; }
}