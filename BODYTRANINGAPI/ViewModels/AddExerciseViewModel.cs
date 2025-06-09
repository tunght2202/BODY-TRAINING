using BODYTRANINGAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BODYTRANINGAPI.ViewModels
{
    public class AddExerciseViewModel
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string DifficultyLevel { get; set; }
        [Required]

        public bool Access { get; set; } // true = public, false = private


        public List<int> ListMuscles { get; set; }
        public List<IFormFile> Images { get; set; }

    }
}
