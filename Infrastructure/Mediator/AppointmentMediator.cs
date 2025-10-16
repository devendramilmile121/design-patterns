using Application.Interfaces;
using Application.Mediator;
namespace Infrastructure.Mediator;
public class AppointmentMediator : IMediator
{
    private readonly IPatientService _patientService;
    public AppointmentMediator(IPatientService patientService) => _patientService = patientService;
    public void Notify(object? sender, string eventName)
    {
        if(eventName == "AppointmentCreated")
        {
            Console.WriteLine($"[Mediator] Notifying billing and doctor scheduling...");    
        } 
        else 
        {
            Console.WriteLine($"[Mediator] Unknown event: {eventName}");
        }
    }
}