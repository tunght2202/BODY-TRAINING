//using BODYTRANINGAPI.Models;
//using BODYTRANINGAPI.ViewModels;
//using Microsoft.EntityFrameworkCore;

//namespace BODYTRANINGAPI.Repository.WorkoutPlanRepo
//{
//    public class WorkoutPlanRepository : IWorkoutPlanRepository
//    {
//        private readonly BODYTRAININGDbContext _context;

//        public WorkoutPlanRepository(BODYTRAININGDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<IEnumerable<WorkoutPlanModel>> GetWorkoutPlansAsync(string userId)
//        {
//            return await _context.WorkoutPlans
//                .Where(w => w.UserId == userId)
//                .Select(w => new WorkoutPlanModel
//                {
//                    PlanId = w.PlanId,
//                    Title = w.Title,
//                    Description = w.Description,
//                    StartDate = w.StartDate,
//                    EndDate = w.EndDate
//                }).ToListAsync();
//        }

//        public async Task<WorkoutPlanModel?> GetWorkoutPlanByIdAsync(int planId)
//        {
//            var plan = await _context.WorkoutPlans.FindAsync(planId);
//            if (plan == null) return null;

//            return new WorkoutPlanModel
//            {
//                PlanId = plan.PlanId,
//                Title = plan.Title,
//                Description = plan.Description,
//                StartDate = plan.StartDate,
//                EndDate = plan.EndDate
//            };
//        }

//        public async Task<bool> AddWorkoutPlanAsync(string userId, CreateWorkoutPlanModel model)
//        {
//            var plan = new WorkoutPlan
//            {
//                UserId = userId,
//                Title = model.Title,
//                Description = model.Description,
//                StartDate = model.StartDate,
//                EndDate = model.EndDate
//            };

//            await _context.WorkoutPlans.AddAsync(plan);
//            return await _context.SaveChangesAsync() > 0;
//        }

//        public async Task<bool> UpdateWorkoutPlanAsync(int planId, CreateWorkoutPlanModel model)
//        {
//            var plan = await _context.WorkoutPlans.FindAsync(planId);
//            if (plan == null) return false;

//            plan.Title = model.Title;
//            plan.Description = model.Description;
//            plan.StartDate = model.StartDate;
//            plan.EndDate = model.EndDate;

//            _context.WorkoutPlans.Update(plan);
//            return await _context.SaveChangesAsync() > 0;
//        }

//        public async Task<bool> DeleteWorkoutPlanAsync(int planId)
//        {
//            var plan = await _context.WorkoutPlans.FindAsync(planId);
//            if (plan == null) return false;

//            _context.WorkoutPlans.Remove(plan);
//            return await _context.SaveChangesAsync() > 0;
//        }
//    }
//}
