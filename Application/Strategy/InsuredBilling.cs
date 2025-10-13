namespace Application.Strategy;
public sealed class InsuredBilling : IBillingStrategy
{
    public decimal CalculateBill(decimal baseAmount) => baseAmount * 0.5m;
}
