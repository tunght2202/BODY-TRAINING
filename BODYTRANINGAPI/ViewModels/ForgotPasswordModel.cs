using System.ComponentModel.DataAnnotations;

namespace BODYTRANINGAPI.ViewModels
{
    public class ForgotPasswordModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }

    }
}
