namespace mlt.api.Models;

public class RssSubscription : BaseModel
{
    public string? Name { get; set; }
    public string? Url { get; set; }
    public bool IsActive { get; set; } = true;
    public string? ShowName { get; set; }
}