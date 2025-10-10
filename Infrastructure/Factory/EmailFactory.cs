namespace Infrastructure.Factory;
/// <summary>
/// Provides a factory for creating email-based notifications.
/// </summary>
/// <remarks>This class is used to instantiate objects that implement the <see cref="INotification"/> interface, 
/// specifically for email notifications. It encapsulates the creation logic, ensuring that the caller  does not need to
/// directly instantiate the notification type.</remarks>
public class EmailFactory
{
    public INotification CreateNotification() => new EmailNotification();
}
