using MediatR;

namespace Producer.Application.Core.Persons.Commands;

public class PersonCommand: IRequest<BaseResponse>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}