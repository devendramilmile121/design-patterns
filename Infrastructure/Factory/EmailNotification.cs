namespace Infrastructure.Factory;
public sealed class EmailNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"[Email] {message}");
    }
}
