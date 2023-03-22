using Commons;
using MediatR;
using Microsoft.Extensions.Configuration;
using Producer.Application.Notifications;
using Producer.Core.Entities;
using Producer.Core.Interfaces.Repository;

namespace Producer.Application.Core.Persons.Commands;

public class PersonCreateHandler : IRequestHandler<PersonCreateCommand, BaseResponse>
{
    private readonly IPersonRepository _repository;
    private readonly IMediator _mediator;
    private readonly NotificationContext _notification;
    private readonly IConfiguration _configuration;

    public PersonCreateHandler(IPersonRepository repository, IMediator mediator, NotificationContext notification, IConfiguration configuration)
    {
        _repository = repository;
        _mediator = mediator;
        _notification = notification;
        _configuration = configuration;
    }

    public async Task<BaseResponse> Handle(PersonCreateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var person = new Person(request.FirstName, request.LastName, request.Email);
            if (!person.Valid)
            {
                _notification.AddNotifications(person.ValidationResult);

                return new BaseResponse { Notifications = _notification.Notifications, };
            }
            
            await _repository.InsertOneAsync(person);

            var produce = new ProduceMessage(_configuration);
            produce.Send(person, "create-person-queue", "CreatePerson", "create-person-queue-key");
            
            return new BaseResponse { Result = person, };
        }
        catch (Exception ex)
        {
            _notification.AddNotification("Error", ex.Message);

            return new BaseResponse { Notifications = _notification.Notifications, };
        }
    }
}