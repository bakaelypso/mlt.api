namespace mlt.api.Repositories;

internal class CustomerBddRepository : BaseBddRepository<Customer>
{
    public CustomerBddRepository(IOptions<MltStationDbSettings> dbSettings) : base(dbSettings, dbSettings.Value.CustomersCollectionName) { }
}