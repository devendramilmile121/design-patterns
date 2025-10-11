using Domain.Entities;

namespace Application.Interfaces;

public interface IPatientService
{
    void Register(Patient patient);
}
