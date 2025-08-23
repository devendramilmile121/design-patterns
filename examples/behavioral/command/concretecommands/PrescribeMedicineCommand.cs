using examples.behavioral.command.receiver;

namespace examples.behavioral.command.concretecommands;

public class PrescribeMedicineCommand : ICommand
{
    private PatientRecord _patientRecoard;
    private string _medicine;

    public PrescribeMedicineCommand(PatientRecord patientRecoard, string medicine)
    {
        _patientRecoard = patientRecoard;
        _medicine = medicine;
    }

    public void Execute() => _patientRecoard.AddRecord($"Prescribed medicine: {_medicine}");

    public void Undo() => _patientRecoard.RemoveRecord($"Prescribed medicine: {_medicine}");
}
