using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories;
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
