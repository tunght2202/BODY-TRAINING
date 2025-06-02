using BODYTRANINGAPI.Models;
using BODYTRANINGAPI.ViewModels;

namespace BODYTRANINGAPI.Repository.MealPlanRepo
{
    public interface IMealPlanRepository
    {
        Task<bool> AddMealPlanAsync(MealPlanModel mealPlanModel, string UserId, IFormFile image);
        Task<IEnumerable<MealPlanModel>> GetMealPlansAsync(string userId);
        Task<MealPlanModel?> GetMealPlanByIdAsync(int id);
        Task<bool> AddMealPlanAsync(string userId, CreateMealPlanModel model);
        Task<bool> UpdateMealPlanAsync(int id, CreateMealPlanModel model);
        Task<bool> DeleteMealPlanAsync(int id);

    }
}
