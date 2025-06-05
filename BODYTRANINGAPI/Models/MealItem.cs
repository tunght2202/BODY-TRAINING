namespace BODYTRANINGAPI.Models
{
    public class MealItem
    {
        public int Id { get; set; }
        public int DailyMealPlanId { get; set; }
        public string MealName { get; set; } // "Bữa 1", "Bữa 2", ...
        public string Description { get; set; } // ví dụ: "cá, gà, táo"
        public int? Calories { get; set; } // có thể null nếu không có calo
        public DailyMealPlan DailyMealPlan { get; set; }
        public ICollection<MealItemImage> MealItemImages { get; set; }

    }

}