using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Goodreads.Core.Entities;

public class ApplicationUser : IdentityUser
{
    [Required]
    public string Fullname { get; set; }
    public string ConfirmationCode { get; set; }
}