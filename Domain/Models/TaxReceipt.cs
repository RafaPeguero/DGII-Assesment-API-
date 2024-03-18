namespace Domain.Models;

public class TaxReceipt
{
    public int Id { get; set; }
    public long TaxPayerId { get; set; }
    public string Ncf { get; set; } = string.Empty;
    public double Amount { get; set; }
    public double Itbis18 { get; set; }
}