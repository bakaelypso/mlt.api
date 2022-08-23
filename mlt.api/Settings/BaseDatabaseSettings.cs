namespace mlt.api.Settings;

public abstract class BaseDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string CustomersCollectionName { get; set; } = null!;
}