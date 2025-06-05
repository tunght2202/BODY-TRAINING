//using BODYTRANINGAPI.Models;
//using BODYTRANINGAPI.Services.Cloudinaries;
//using BODYTRANINGAPI.ViewModels;
//using Microsoft.EntityFrameworkCore;

//namespace BODYTRANINGAPI.Repository.MealPlanRepo
//{
//    public class MealPlanRepository : IMealPlanRepository
//    {
//        private readonly BODYTRAININGDbContext _context;
//        private readonly CloudinaryService _cloudinaryService;

//        public MealPlanRepository(BODYTRAININGDbContext context
//            , CloudinaryService cloudinaryService)
//        {
//            _context = context;
//            _cloudinaryService = cloudinaryService;
//        }

//        public async Task<bool> AddMealPlanAsync(MealPlanModel mealPlanModel, string UserId, IFormFile image)
//        {
//            try
//            {
//                var mealPlan = new MealPlan
//                {
//                    UserId = UserId,
//                    MealType = mealPlanModel.MealType,
//                    Description = mealPlanModel.Description,
//                    Calories = mealPlanModel.Calories,
//                    CreatedAt = DateTime.UtcNow
//                };
//                if (image != null)
//                {
//                    var imageUrl = _cloudinaryService.UploadImageAsync(image).Result;
//                    mealPlan.PhotoUrl = imageUrl;
//                }
//                _context.MealPlans.Add(mealPlan);
//                var result = _context.SaveChangesAsync().Result;
//                return result > 0 ? true : false;
//            }
//            catch (Exception ex)
//            {
//                // Log the exception (not implemented here)
//                return false;
//            } 
//        }

//        public async Task<MealPlanModel?> GetMealPlanByIdAsync(int id)
//        {
//            var meal = await _context.MealPlans.FindAsync(id);
//            if (meal == null) return null;

//            return new MealPlanModel
//            {
//                MealPlanId = meal.MealPlanId,
//                MealType = meal.MealType,
//                Description = meal.Description,
//                Calories = meal.Calories,
//                PhotoUrl = meal.PhotoUrl,
//                CreatedAt = meal.CreatedAt
//            };
//        }

//        public async Task<bool> AddMealPlanAsync(string userId, CreateMealPlanModel model)
//        {
//            var meal = new MealPlan
//            {
//                UserId = userId,
//                MealType = model.MealType,
//                Description = model.Description,
//                Calories = model.Calories,
//                PhotoUrl = model.PhotoUrl,
//                CreatedAt = DateTime.UtcNow
//            };
//            await _context.MealPlans.AddAsync(meal);
//            return await _context.SaveChangesAsync() > 0;
//        }

//        public async Task<bool> UpdateMealPlanAsync(int id, CreateMealPlanModel model)
//        {
//            var meal = await _context.MealPlans.FindAsync(id);
//            if (meal == null) return false;

//            meal.MealType = model.MealType;
//            meal.Description = model.Description;
//            meal.Calories = model.Calories;
//            meal.PhotoUrl = model.PhotoUrl;

//            _context.MealPlans.Update(meal);
//            return await _context.SaveChangesAsync() > 0;
//        }

//        public async Task<bool> DeleteMealPlanAsync(int id)
//        {
//            var meal = await _context.MealPlans.FindAsync(id);
//            if (meal == null) return false;

//            _context.MealPlans.Remove(meal);
//            return await _context.SaveChangesAsync() > 0;
//        }

//        public async Task<IEnumerable<MealPlanModel>> GetMealPlansAsync(string userId)
//        {
//            return await _context.MealPlans
//                .Where(m => m.UserId == userId)
//                .OrderByDescending(m => m.CreatedAt)
//                .Select(m => new MealPlanModel
//                {
//                    MealPlanId = m.MealPlanId,
//                    MealType = m.MealType,
//                    Description = m.Description,
//                    Calories = m.Calories,
//                    PhotoUrl = m.PhotoUrl,
//                    CreatedAt = m.CreatedAt
//                }).ToListAsync();
//        }
//    }
//}
