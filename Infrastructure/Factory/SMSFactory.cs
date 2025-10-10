namespace Infrastructure.Factory;
/// <summary>
/// Provides a factory for creating SMS notification instances.
/// </summary>
/// <remarks>This class is used to create instances of <see cref="SMSNotification"/>  through the <see
/// cref="CreateNotification"/> method. It follows the factory design pattern  to encapsulate the creation logic for SMS
/// notifications.</remarks>
public class SMSFactory
{
    public INotification CreateNotification() => new SMSNotification();
}
