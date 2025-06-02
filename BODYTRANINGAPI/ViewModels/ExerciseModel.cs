namespace BODYTRANINGAPI.ViewModels
{
    public class ExerciseModel
    {
        public int ExerciseId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? DifficultyLevel { get; set; }
        public TimeOnly? Duration { get; set; }
        public string? MuscleName { get; set; }
    }
}
