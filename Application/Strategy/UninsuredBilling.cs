namespace Application.Strategy;
public sealed class UninsuredBilling : IBillingStrategy
{
    public decimal CalculateBill(decimal baseAmount) => baseAmount;
}
