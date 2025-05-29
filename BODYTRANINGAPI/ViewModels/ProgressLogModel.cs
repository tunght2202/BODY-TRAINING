using System.ComponentModel.DataAnnotations;

namespace BODYTRANINGAPI.ViewModels
{
    public class ProgressLogModel
    {

        [Required(ErrorMessage = "Height is required.")]
        [Range(50, 250, ErrorMessage = "Height must from 50cm to 250cm.")]
        public decimal? Height { get; set; }

        [Required(ErrorMessage = "Weight is required.")]
        [Range(20, 300, ErrorMessage = "Weight must from 20kg to 300kg.")]
        public decimal? Weight { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Calories burned cannot be negative.")]
        public int? CaloriesBurned { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Calories consumed cannot be negative.")]
        public int? CaloriesConsumed { get; set; }
    }
}
