namespace Infrastructure.Factory;
/// <summary>
/// Represents an SMS notification mechanism for sending messages.
/// </summary>
/// <remarks>This class provides functionality to send SMS notifications by implementing the <see
/// cref="INotification"/> interface. It is designed to output the message to the console for demonstration
/// purposes.</remarks>
public class SMSNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"[SMS] {message}");
    }
}
