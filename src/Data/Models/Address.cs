namespace MyLibrary.Data.Models;

public class Address : IUniqueEntity
{
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    [Unique]
    public string FullAddress => $"{Street}, {PostalCode}, {City}";

    public string GetUniqueKey() => FullAddress;
    public override string ToString() => FullAddress;
}