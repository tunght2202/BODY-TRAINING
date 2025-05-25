using System;
using System.ComponentModel.DataAnnotations;

namespace BODYTRANINGAPI.ViewModels
{
    public class RegisterRequestModel
    {
        [Required(ErrorMessage = "Username is required.")]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Username only includes characters from A - Z and numbers.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^0\d{9}$", ErrorMessage = "Phone number must be 10 digits and start with 0.")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Height is required.")]
        [Range(50, 250, ErrorMessage = "Height must from 50cm to 250cm.")]
        public decimal? Height { get; set; }

        [Required(ErrorMessage = "Weight is required.")]
        [Range(20, 300, ErrorMessage = "Weight must from 20kg to 300kg.")]
        public decimal? Weight { get; set; }
        public string? HealthStatus { get; set; }
        public string? FullName { get; set; }
        [Required(ErrorMessage = "Age is required.")]
        [Range(1, 120, ErrorMessage = "Age must in range from 1 to 120.")]
        public int Age { get; set; }

        [RegularExpression("^(Male|Female)$", ErrorMessage = "Gender can only be 'Male' or 'Female'.")]
        public string? Gender { get; set; }


    }
}
