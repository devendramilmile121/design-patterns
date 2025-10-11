using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories;
/// <summary>
/// Provides a repository for managing <see cref="Patient"/> entities in memory.
/// </summary>
/// <remarks>This repository maintains an in-memory collection of <see cref="Patient"/> objects.  It supports
/// adding new patients and retrieving all stored patients.  This implementation is not thread-safe and is intended for
/// use in single-threaded or test scenarios.</remarks>
public sealed class PatientRepository : IRepository<Patient>
{
    private readonly List<Patient> _patients = new();
    public void Add(Patient entity)
    {
        _patients.Add(entity);
    }

    public IEnumerable<Patient> GetAll()
    {
        return _patients;
    }
}
