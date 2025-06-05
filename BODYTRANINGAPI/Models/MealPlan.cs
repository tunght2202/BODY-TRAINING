namespace BODYTRANINGAPI.Models;

public partial class MealPlan
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public string PlanName { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public ICollection<DailyMealPlan> DailyMeals { get; set; }
    public virtual User? User { get; set; }
}
