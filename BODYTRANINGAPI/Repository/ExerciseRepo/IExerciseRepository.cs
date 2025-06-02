using BODYTRANINGAPI.ViewModels;

namespace BODYTRANINGAPI.Repository.ExerciseRepo
{
    public interface IExerciseRepository
    {
        Task<IEnumerable<ExerciseModel>> GetAllAsync();
        Task<ExerciseModel?> GetByIdAsync(int id);
        Task<bool> AddAsync(CreateExerciseModel model, string createdBy);
        Task<bool> UpdateAsync(int id, CreateExerciseModel model);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<ExerciseModel>> GetByMuscleIdAsync(int muscleId);
    }
}
