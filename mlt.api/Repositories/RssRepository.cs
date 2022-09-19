namespace mlt.api.Repositories;

public class RssRepository : IBaseRepository<FreshRss>
{
    private readonly IOptions<RssConfig> _rssSettings;

    public RssRepository(IOptions<RssConfig> rssSettings)
        => _rssSettings = rssSettings;

    private async Task<List<FreshRss>> AggregateItemsFromRss()
    {
        var formContent = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("api_key", _rssSettings.Value.FeverApiKey)
        });

        var myHttpClient = new HttpClient();
        var foundResults = true;
        var lastId = (double)0;
        var result = new List<FreshRss>();

        while (foundResults)
        {
            var response = await myHttpClient.PostAsync(new Uri($"http://192.168.0.100:7200/api/fever.php?api&items&since_id={lastId}"), formContent);

            var values = await response.Content.ReadAsStringAsync();
            dynamic data = JsonConvert.DeserializeObject(values)!;
            var items = data.items;

            var items2 = ((JArray)items).Select(x => new FreshRss
            {
                RssId = (double)x["id"]!,
                Title = (string)x["title"]!,
                Author = (string)x["author"]!,
                Url = (string)x["url"]!,
                Html = (string)x["html"]!,
                FeedId = (int)x["feed_id"]!,
                IsSaved = (bool)x["is_saved"]!,
                IsRead = (bool)x["is_read"]!,
            }).ToList();

            if (items2.Count > 0)
            {
                foundResults = true;
                result.AddRange(items2);
                result = result.Distinct().ToList();
                lastId = result.Max(x => x.RssId);
            }
            else
            {
                foundResults = false;
            }
        }

        return result.OrderBy(x => x.FeedId).ToList();
    }

    public async Task<List<FreshRss>> GetAsync()
        => await AggregateItemsFromRss();

    public Task<FreshRss?> GetAsync(Guid id)
        => throw new NotImplementedException();

    public Task CreateAsync(FreshRss createdModel)
        => throw new NotImplementedException();

    public Task UpdateAsync(Guid id, FreshRss updatedModel)
        => throw new NotImplementedException();

    public Task RemoveAsync(Guid id)
        => throw new NotImplementedException();
}