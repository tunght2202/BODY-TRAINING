using System.ComponentModel.DataAnnotations;

namespace BODYTRANINGAPI.ViewModels
{
    public class ResetPasswordModel
    {

        [Required, MinLength(6)]
        public string NewPassword { get; set; }

    }
}
