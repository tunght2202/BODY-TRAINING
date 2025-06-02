using BODYTRANINGAPI.Models;

namespace BODYTRANINGAPI.ViewModels
{
    public class MealPlanModel
    {
        public int MealPlanId { get; set; }
        public string? MealType { get; set; }
        public string? Description { get; set; }
        public int? Calories { get; set; }
        public string? PhotoUrl { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
