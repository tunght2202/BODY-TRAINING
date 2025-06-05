using System.ComponentModel.DataAnnotations;

namespace BODYTRANINGAPI.Models;

public class WorkoutSchedule
{
    [Key]
    public int ScheduleId { get; set; }
    public int PlanId { get; set; }  // Mối quan hệ với WorkoutPlan
    public DayOfWeek DayOfWeek { get; set; }  // Thứ trong tuần
    public string Status { get; set; }  // Trạng thái (e.g., Completed, Pending, Rest)

    // Mối quan hệ với WorkoutPlan
    public virtual WorkoutPlan WorkoutPlan { get; set; }
    public virtual WorkoutProgress WorkoutProgress { get; set; }

    // Mối quan hệ với các bài tập trong lịch tập
    public ICollection<WorkoutScheduleExercise> WorkoutScheduleExercises { get; set; } = new List<WorkoutScheduleExercise>();
}
