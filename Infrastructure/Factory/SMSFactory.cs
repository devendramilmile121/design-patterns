namespace Infrastructure.Factory;
public class SMSFactory
{
    public INotification CreateNotification() => new SMSNotification();
}
