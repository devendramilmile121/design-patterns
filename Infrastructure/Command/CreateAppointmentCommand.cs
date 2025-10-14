using Application.Commands;
using Domain.Entities;

namespace Infrastructure.Command;
public sealed class CreateAppointmentCommand : ICommand
{
    private readonly Appointment _appointment;
    public CreateAppointmentCommand(Appointment appointment)
    {
        _appointment = appointment;
    }

    public void Execute()
    {
        Console.WriteLine($"[Command] Appointment created for {_appointment.Patient?.Name} with {_appointment.Doctor?.Name} on {_appointment.Date:d}");
    }
}
