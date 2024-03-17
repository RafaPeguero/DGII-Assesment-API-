namespace Domain.Models;

public class TaxReceipt
{
    public int Id { get; set; }
    public long TaxPayerId { get; set; }
    public string Ncf { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public decimal Itbis18 { get; set; }
}