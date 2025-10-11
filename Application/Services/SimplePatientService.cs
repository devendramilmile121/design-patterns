using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;
/// <summary>
/// Provides a simple implementation of the <see cref="IPatientService"/> interface for managing patient
/// registrations.
/// </summary>
/// <remarks>This service allows registering new patients by adding them to the underlying repository.  It
/// is designed for basic use cases and writes a log message to the console upon successful registration.</remarks>
public class SimplePatientService : IPatientService
{
    private readonly IRepository<Patient> _repo;
    public SimplePatientService(IRepository<Patient> repo) => _repo = repo;
    public void Register(Patient patient)
    {
        _repo.Add(patient);
        Console.WriteLine($"[PatientService] Registered: {patient.Name}");
    }
}