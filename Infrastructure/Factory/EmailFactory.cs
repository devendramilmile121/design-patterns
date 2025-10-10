namespace Infrastructure.Factory;
public class EmailFactory
{
    public INotification CreateNotification() => new EmailNotification();
}
