namespace Infrastructure.Factory;
/// <summary>
/// Represents a notification mechanism that sends messages via email.
/// </summary>
/// <remarks>This class provides functionality to send notifications by email. It implements the <see
/// cref="INotification"/> interface.</remarks>
public sealed class EmailNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"[Email] {message}");
    }
}
