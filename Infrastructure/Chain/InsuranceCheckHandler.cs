using Domain.Entities;

namespace Infrastructure.Chain;

public class InsuranceCheckHandler : ApprovalHandler
{
    public override void Handle(Patient patient)
    {
        if (string.IsNullOrEmpty(patient.InsuranceProvider))
        {
            Console.WriteLine($"[Chain] ❌ Insurance check for {patient.Name} failed.");
        }
        else
        {
            Console.WriteLine($"[Chain] ✅ Insurance check for {patient.Name} completed.");
            Next?.Handle(patient);
        }
    }
}