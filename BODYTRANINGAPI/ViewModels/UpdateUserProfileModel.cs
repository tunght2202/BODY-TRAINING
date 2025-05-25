using System.ComponentModel.DataAnnotations;

namespace BODYTRANINGAPI.ViewModels
{
    public class UpdateUserProfileModel
    {
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Username only includes characters from A - Z and numbers.")]
        public string? UserName { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [MinLength(6)]
        public string? Password { get; set; }
        [RegularExpression(@"^0\d{9}$", ErrorMessage = "Phone number must be 10 digits and start with 0.")]
        public string? PhoneNumber { get; set; }

        public string? FullName { get; set; }
        [Range(50, 250, ErrorMessage = "Height must from 50cm to 250cm.")]
        public decimal? Height { get; set; }

        [Range(20, 300, ErrorMessage = "Weight must from 20kg to 300kg.")]
        public decimal? Weight { get; set; }
        public string? HealthStatus { get; set; }
        [Required(ErrorMessage = "Age is required.")]
        [Range(1, 120, ErrorMessage = "Age must in range from 1 to 120.")]
        public int? Age { get; set; }
        [RegularExpression("^(Male|Female)$", ErrorMessage = "Gender can only be 'Male' or 'Female'.")]
        public string? Gender { get; set; }

        public IFormFile? Avatar { get; set; }
    }
}
