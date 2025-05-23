namespace BODYTRANINGAPI.Models;

public partial class Exercise
{
    public int ExerciseId { get; set; }

    public string? CreatedBy { get; set; }

    public int? MuscleId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? DifficultyLevel { get; set; }

    public TimeOnly? Duration { get; set; }

    public bool? Access { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual Muscle? Muscle { get; set; }

    public virtual ICollection<ExerciseMedia> ExerciseMedia { get; set; }

}
