using MediatR;

namespace Goodreads.Application.Core.Users;

public class UserCommand : IRequest<GenericResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}