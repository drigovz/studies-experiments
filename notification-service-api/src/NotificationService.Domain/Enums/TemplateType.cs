using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NotificationService.Domain.Enums
{
    public enum TemplateType
    {
        [Display(Name = "Email")]
        [Description("Email")]
        Email,
        [Display(Name = "ResetPassword")]
        [Description("ResetPassword")]
        ResetPassword,
        [Display(Name = "Pdf")]
        [Description("Pdf")]
        Pdf,
        [Display(Name = "GeneralNotifications")]
        [Description("GeneralNotifications")]
        GeneralNotifications,
    }
}
