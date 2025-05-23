namespace BODYTRANINGAPI.Models;

public partial class MealPlan
{
    public int MealPlanId { get; set; }

    public string? UserId { get; set; }

    public string? MealType { get; set; }

    public string? Description { get; set; }

    public int? Calories { get; set; }

    public string? PhotoUrl { get; set; }

    public virtual User? User { get; set; }
}
