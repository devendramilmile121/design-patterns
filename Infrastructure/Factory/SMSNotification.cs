namespace Infrastructure.Factory;
public class SMSNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"[SMS] {message}");
    }
}
