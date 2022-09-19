namespace mlt.common.Settings;

public class MltStationDbSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string CustomersCollectionName { get; set; } = null!;
    public string RssCollectionName { get; set; } = null!;
}