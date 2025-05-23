using Microsoft.AspNetCore.Identity;

namespace BODYTRANINGAPI.Models;

public partial class User : IdentityUser
{

    public string? FullName { get; set; }

    public string? Gender { get; set; }

    public int? Age { get; set; }

    public decimal? Height { get; set; }

    public decimal? Weight { get; set; }

    public decimal? Bmi { get; set; }
    public string? ImageURL { get; set; }

    public string? HealthStatus { get; set; }


    public DateTime? DateCreated { get; set; } = DateTime.Now;

    public virtual ICollection<Exercise> Exercises { get; set; }

    public virtual ICollection<MealPlan> MealPlans { get; set; }

    public virtual ICollection<ProgressLog> ProgressLogs { get; set; }

    public virtual ICollection<WorkoutPlan> WorkoutPlans { get; set; }
}
