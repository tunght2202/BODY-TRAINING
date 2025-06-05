namespace BODYTRANINGAPI.Models
{
    public class DailyMealPlan
    {
        public int Id { get; set; }
        public int MealPlanId { get; set; }
        public DayOfWeek DayOfWeek { get; set; } // Thứ 2, Thứ 3, ...
        public MealPlan MealPlan { get; set; }
        public ICollection<MealItem> Meals { get; set; }
    }

}