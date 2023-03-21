using MediatR;
using NotificationService.Domain.Entities;

namespace NotificationService.Application.Core.Templates.Queries
{
    public class GetTemplatesQuery : IRequest<IEnumerable<Template>>
    { }
}
