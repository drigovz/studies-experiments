namespace NotificationService.Application.Core.Templates.Commands
{
    public class UpdateTemplateCommand : TemplateCommand
    {
        public int Id { get; set; }

        public UpdateTemplateCommand(int id)
        {
            Id = id;
        }
    }
}
