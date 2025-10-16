using Domain.Entities;
namespace Infrastructure.Chain;
public abstract class ApprovalHandler
{
    protected ApprovalHandler? Next { get; set; }
    public void SetNext(ApprovalHandler next) => Next = next;
    public abstract void Handle(Patient patient);
}