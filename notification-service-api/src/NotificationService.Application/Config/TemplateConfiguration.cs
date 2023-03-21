using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating;
using RazorEngine.Text;

namespace NotificationService.Application.Config
{
    public static class TemplateConfiguration
    {
        public static string Build(object model, string file)
        {
            try
            {
                string templateFile = Path.Combine($"{Directory.GetCurrentDirectory()}/Templates/", file),
                       templateKey = Guid.NewGuid().ToString(),
                       html = File.ReadAllText(templateFile); 

                var config = new TemplateServiceConfiguration
                {
                    Language = Language.CSharp,
                    EncodedStringFactory = new HtmlEncodedStringFactory(),
                    Debug = true,
                };
                RazorEngineService.Create(config);

                var result = Engine.Razor.RunCompile(new LoadedTemplateSource(html), templateKey, null, model);

                return result;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
    }
}
