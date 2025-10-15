namespace Infrastructure.Decorator;
public sealed class BasicBilling : IBilling
{
    private readonly decimal _amount;
    public BasicBilling(decimal amount)
    {
        _amount = amount;
    }
    public decimal GetAmount()
    {
        return _amount;
    }
}
