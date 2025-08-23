namespace examples.behavioral.command.receiver;

public class PatientRecord
{
    public string Name { get; }
    private List<string> _medicalHistory = new List<string>();

    public PatientRecord(string name)
    {
        Name = name;
    }

    public void AddRecord(string entry)
    {
        _medicalHistory.Add(entry);
        Console.WriteLine($"[Added] {entry} for {Name}");
    }

    public void RemoveRecord(string entry)
    {
        _medicalHistory.Remove(entry);
        Console.WriteLine($"[Removed] {entry} for {Name}");
    }

    public void ShowHistory()
    {
        Console.WriteLine($"\n--- Medical History of {Name} ---");
        if (_medicalHistory.Count == 0)
        {
            Console.WriteLine("No medical history.");
            return;
        }
        foreach (var entry in _medicalHistory)
        {
            Console.WriteLine($"- {entry}");
        }
    }
}
