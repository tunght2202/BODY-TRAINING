namespace BODYTRANINGAPI.ViewModels
{
    public class GetExerciseViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int DifficultyLevel { get; set; }

        public string ExerciseType { get; set; }

        public string ImageUrl { get; set; } // Optional field for exercise image URL
    }
}
