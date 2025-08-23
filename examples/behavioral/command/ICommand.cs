namespace examples.behavioral.command;

public interface ICommand
{
    void Execute();
    void Undo();
}
