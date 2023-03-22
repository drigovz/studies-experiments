namespace Producer.Core.Interfaces.Events;

public interface IPersonCreatedEvent
{
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public DateTime CreatedAt { get; }
}