namespace Application.Strategy;
public interface IBillingStrategy
{
    decimal CalculateBill(decimal baseAmount);
}
