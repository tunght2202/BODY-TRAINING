namespace BODYTRANINGAPI.Models;

public partial class WorkoutSchedule
{
    public int ScheduleId { get; set; }

    public int? PlanId { get; set; }

    public DateOnly? WorkoutDate { get; set; }

    public TimeOnly? WorkoutTime { get; set; }

    public string? Status { get; set; }

    public virtual WorkoutPlan? Plan { get; set; }
}
