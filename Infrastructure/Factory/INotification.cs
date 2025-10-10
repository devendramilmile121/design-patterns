namespace Infrastructure.Factory;
/// <summary>
/// Represents a notification mechanism for sending messages.
/// </summary>
/// <remarks>This interface defines a contract for sending notifications. Implementations may vary in how the 
/// message is delivered (e.g., email, SMS, push notifications, etc.).</remarks>
public interface INotification
{
    void Send(string message);
}
