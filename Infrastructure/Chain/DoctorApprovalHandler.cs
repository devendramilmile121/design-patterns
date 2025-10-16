using Domain.Entities;

namespace Infrastructure.Chain;

public class DoctorApprovalHandler : ApprovalHandler
{
    public override void Handle(Patient patient)
    {
        Console.WriteLine($"[Chain] ✅ Doctor approval for {patient.Name} completed.");
        Next?.Handle(patient);
    }
}