namespace BODYTRANINGAPI.Models;

public partial class Exercise
{
    public int ExerciseId { get; set; }
    public int ExercisePlanDetailId { get; set; }
    public string UserId { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool Access { get; set; }
    public virtual User User { get; set; }
    public virtual ICollection<ExerciseMuscle> ExerciseMuscles { get; set; }
    public virtual ICollection<ExerciseMedia> ExerciseMedias { get; set; }
    public ICollection<WorkoutScheduleExercise> WorkoutScheduleExercises { get; set; }

}
