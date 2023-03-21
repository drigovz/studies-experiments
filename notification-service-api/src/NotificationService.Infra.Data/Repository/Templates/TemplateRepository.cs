using Microsoft.EntityFrameworkCore;
using NotificationService.Domain.Entities;
using NotificationService.Domain.Interfaces;
using NotificationService.Infra.Data.Context;

namespace NotificationService.Infra.Data.Repository.Templates
{
    public class TemplateRepository : BaseRepository<Template, int>, ITemplateRepository
    {
        private readonly DbSet<Template> _dataset;

        public TemplateRepository(AppDbContext context)
            : base(context)
        {
            _dataset = context.Set<Template>();
        }

        public async Task<Template> GetBySubjectAsync(string subject) =>
            await _dataset.FirstOrDefaultAsync(x => x.Subject.Equals(subject));

        public bool SubjectExists(string subject) =>
            _dataset.Select(x => x.Subject.Equals(subject)) != null ? true : false;
    }
}
