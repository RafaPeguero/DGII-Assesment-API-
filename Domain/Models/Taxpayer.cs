namespace Domain.Models;

public class Taxpayer
{
    public long TaxpayerId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}