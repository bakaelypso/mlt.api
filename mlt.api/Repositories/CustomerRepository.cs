using mlt.api.Settings;

namespace mlt.api.Repositories;

internal class CustomerRepository : IBaseRepository<Customer>
{
    private readonly IMongoCollection<Customer> _customersCollection;

    public CustomerRepository(IOptions<CustomersDatabaseSettings> customersDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            customersDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            customersDatabaseSettings.Value.DatabaseName);

        _customersCollection = mongoDatabase.GetCollection<Customer>(customersDatabaseSettings.Value.CustomersCollectionName);
    }

    public Task Create(Customer document)
        => document is null ? Task.CompletedTask : _customersCollection.InsertOneAsync(document);

    public Task<Customer> GetById(Guid id)
        => _customersCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public IAsyncEnumerable<Customer> GetAll()
    {
        Console.WriteLine("Reading");
        return _customersCollection.Find(_ => true).ToAsyncEnumerable();
    }

    public Task Update(Guid id, Customer updatedDocument)
        => _customersCollection.ReplaceOneAsync(x => x.Id == updatedDocument.Id, updatedDocument);

    public Task Delete(Guid id) 
    => _customersCollection.DeleteOneAsync(x => x.Id == id);

}