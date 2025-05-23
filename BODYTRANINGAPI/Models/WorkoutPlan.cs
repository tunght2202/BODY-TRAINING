namespace BODYTRANINGAPI.Models;

public partial class WorkoutPlan
{
    public int PlanId { get; set; }

    public string? UserId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public virtual User? User { get; set; }

    public virtual ICollection<WorkoutSchedule> WorkoutSchedules { get; set; }
}
