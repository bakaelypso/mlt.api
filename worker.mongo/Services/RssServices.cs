namespace worker.mongo.Services;

public class RssService
{
    private readonly IMongoCollection<RssModel> _rsssCollection;

    public RssService(IOptions<MltStationDatabaseSettings> mltStationDatabaseSettings)
    {
        var mongoClient = new MongoClient(mltStationDatabaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(mltStationDatabaseSettings.Value.DatabaseName);
        _rsssCollection = mongoDatabase.GetCollection<RssModel>(mltStationDatabaseSettings.Value.RssCollectionName);
    }

    public async Task<List<RssModel>> GetAsync()
        => await _rsssCollection.Find(_ => true).ToListAsync();

    public async Task<RssModel?> GetAsync(string id)
        => await _rsssCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(RssModel newRss)
        => await _rsssCollection.InsertOneAsync(newRss);

    public async Task UpdateAsync(string id, RssModel updatedRss)
        => await _rsssCollection.ReplaceOneAsync(x => x.Id == id, updatedRss);

    public async Task RemoveAsync(string id)
        => await _rsssCollection.DeleteOneAsync(x => x.Id == id);
}