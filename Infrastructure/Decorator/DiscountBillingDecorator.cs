namespace Infrastructure.Decorator;
public sealed class DiscountBillingDecorator : IBilling
{
    private readonly IBilling _billing;
    public DiscountBillingDecorator(IBilling billing)
    {
        _billing = billing;
    }
    public decimal GetAmount()
    {
        return _billing.GetAmount() * 0.9m;
    }
}
