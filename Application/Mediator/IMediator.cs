namespace Application.Mediator;

public interface IMediator
{
    void Notify(object? sender, string eventName);
}