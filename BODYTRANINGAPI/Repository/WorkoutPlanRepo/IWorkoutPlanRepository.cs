using BODYTRANINGAPI.ViewModels;

namespace BODYTRANINGAPI.Repository.WorkoutPlanRepo
{
    public interface IWorkoutPlanRepository
    {
        Task<IEnumerable<WorkoutPlanModel>> GetWorkoutPlansAsync(string userId);
        Task<WorkoutPlanModel?> GetWorkoutPlanByIdAsync(int planId);
        Task<bool> AddWorkoutPlanAsync(string userId, CreateWorkoutPlanModel model);
        Task<bool> UpdateWorkoutPlanAsync(int planId, CreateWorkoutPlanModel model);
        Task<bool> DeleteWorkoutPlanAsync(int planId);
    }
}
