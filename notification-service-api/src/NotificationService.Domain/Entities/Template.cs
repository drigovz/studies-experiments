using NotificationService.Domain.Enums;
using NotificationService.Domain.Validations;

namespace NotificationService.Domain.Entities
{
    public class Template : BaseEntity
    {
        public string Title { get; private set; }
        public string Subject { get; private set; }
        public string File { get; private set; }
        public TemplateType Type { get; private set; }

        public Template(string title, string subject, string file, TemplateType type)
        {
            Title = title;
            Subject = subject;
            File = file;
            Type = type;

            EntityValidation(this, new TemplateValidator());
        }
    }
}
