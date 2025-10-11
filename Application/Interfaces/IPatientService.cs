using Domain.Entities;

namespace Application.Interfaces;
/// <summary>
/// Defines operations for managing patient records.
/// </summary>
/// <remarks>This interface provides methods for registering and managing patient information. Implementations of
/// this interface should ensure that patient data is handled securely and in compliance with applicable
/// regulations.</remarks>
public interface IPatientService
{
    void Register(Patient patient);
}
