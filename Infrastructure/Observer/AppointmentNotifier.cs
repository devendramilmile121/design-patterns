namespace Infrastructure.Observer;
public class AppointmentNotifier
{
    public event Action<string>? AppointmentUpdated;
    public void Notify(string message) => AppointmentUpdated?.Invoke(message);
}
