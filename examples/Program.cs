using examples.behavioral.command.concretecommands;
using examples.behavioral.command.invoker;
using examples.behavioral.command.receiver;

var patient = new PatientRecord("John Doe");
var invoker = new MedicalCommandInvoker();

// Commands
var prescribe = new PrescribeMedicineCommand(patient, "Amoxicillin");

// Execute actions
invoker.ExecuteCommand(prescribe);
patient.ShowHistory();

// Undo last action
Console.WriteLine("\nUndo last action:");
invoker.Undo();
patient.ShowHistory();

// Redo last action
Console.WriteLine("\nRedo last action:");
invoker.Redo();
patient.ShowHistory();