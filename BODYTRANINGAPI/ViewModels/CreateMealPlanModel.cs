using System.ComponentModel.DataAnnotations;

namespace BODYTRANINGAPI.ViewModels
{
    public class CreateMealPlanModel
    {
        [Required]
        [StringLength(50)]
        public string MealType { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Range(0, 10000)]
        public int? Calories { get; set; }

        [Url]
        public string? PhotoUrl { get; set; }
    }
}
