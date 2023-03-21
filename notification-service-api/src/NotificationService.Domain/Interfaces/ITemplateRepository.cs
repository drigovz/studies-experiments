using NotificationService.Domain.Entities;
using NotificationService.Domain.Interfaces.Repository;

namespace NotificationService.Domain.Interfaces
{
    public interface ITemplateRepository : IBaseRepository<Template, int>
    {
        Task<Template> GetBySubjectAsync(string subject);
        bool SubjectExists(string subject);
    }
}
