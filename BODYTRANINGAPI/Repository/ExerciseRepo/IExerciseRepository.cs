using BODYTRANINGAPI.Models;
using BODYTRANINGAPI.ViewModels;

namespace BODYTRANINGAPI.Repository.ExerciseRepo
{
    public interface IExerciseRepository : IRepository<Exercise>
    {
        Task<IEnumerable<Exercise>> GetAllByUserAsync(string userId);
        Task<IEnumerable<Exercise>> GetExercisesByTitleByUserAsync(string exerciseTitle);
        Task<IEnumerable<Exercise>> GetExercisesByMuscleByUserAsync(int muscleId);
        Task<IEnumerable<Exercise>> GetExercisesByDifficultLevelByUserAsync(string difficultLevel);
        Task AddExerciseAsync(Exercise exercise, List<int> muscles, List<String> media);
        Task<string> PushImage(IFormFile image);
        Task<List<string>> PushListImage(List<IFormFile> listImage);

    }
}
