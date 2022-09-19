namespace mlt.common.Repositories;

public abstract class BaseBddRepository<T> : IBaseRepository<T>
    where T : BaseModel
{
    private readonly IMongoCollection<T> _collection;

    protected BaseBddRepository(IOptions<MltStationDbSettings> dbSettings, string collectionName)
    {
        var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
        
        _collection = mongoDatabase.GetCollection<T>(collectionName);
    }
    
    public async Task<List<T>> GetAsync()
        => await _collection.Find(_ => true).ToListAsync();

    public async Task<T?> GetAsync(Guid id)
        => await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(T createdModel)
        => await _collection.InsertOneAsync(createdModel);

    public async Task UpdateAsync(Guid id, T updatedModel)
        => await _collection.ReplaceOneAsync(x => x.Id == id, updatedModel);

    public async Task RemoveAsync(Guid id)
        => await _collection.DeleteOneAsync(x => x.Id == id);
}