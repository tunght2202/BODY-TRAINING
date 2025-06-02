using System.ComponentModel.DataAnnotations;

namespace BODYTRANINGAPI.ViewModels
{
    public class CreateExerciseModel
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [StringLength(50)]
        public string? DifficultyLevel { get; set; }

        public TimeOnly? Duration { get; set; }

        [Required]
        public int MuscleId { get; set; }
    }
}
