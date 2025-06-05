namespace BODYTRANINGAPI.ViewModels
{
    public class ExerciseModel
    {
        public int ExerciseId { get; set; }
        public int ExercisePlanDetailId { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool Access { get; set; }
    }
}
