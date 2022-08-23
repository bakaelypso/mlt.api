namespace worker.mongo.Models;

public class MltStationDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string RssCollectionName { get; set; } = null!;
}