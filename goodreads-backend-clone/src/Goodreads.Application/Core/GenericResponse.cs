using Goodreads.Application.Notifications;

namespace Goodreads.Application.Core;

public abstract class GenericResponse
{
    public dynamic? Result { get; set; } = default;

    public IEnumerable<Notification>? Notifications { get; set; }
}