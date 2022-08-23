namespace mlt.api.Models;

internal class Customer : IIdentifiableDocument
{
    public Guid Id { get; set; }
    
    public string FullName { get; set; }
}