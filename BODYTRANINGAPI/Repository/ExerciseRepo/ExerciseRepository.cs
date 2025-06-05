//using BODYTRANINGAPI.Models;
//using BODYTRANINGAPI.ViewModels;
//using Microsoft.EntityFrameworkCore;

//namespace BODYTRANINGAPI.Repository.ExerciseRepo
//{
//    public class ExerciseRepository : IExerciseRepository
//    {
//        private readonly BODYTRAININGDbContext _context;
//        public ExerciseRepository(BODYTRAININGDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<IEnumerable<ExerciseModel>> GetAllAsync()
//        {
//            return await _context.Exercises
//                .Include(e => e.Muscle)
//                .Select(e => new ExerciseModel
//                {
//                    ExerciseId = e.ExerciseId,
//                    Title = e.Title,
//                    Description = e.Description,
//                    DifficultyLevel = e.DifficultyLevel,
//                    Duration = e.Duration,
//                    MuscleName = e.Muscle!.Name
//                }).ToListAsync();
//        }

//        public async Task<ExerciseModel?> GetByIdAsync(int id)
//        {
//            var e = await _context.Exercises.Include(x => x.Muscle).FirstOrDefaultAsync(x => x.ExerciseId == id);
//            if (e == null) return null;

//            return new ExerciseModel
//            {
//                ExerciseId = e.ExerciseId,
//                Title = e.Title,
//                Description = e.Description,
//                DifficultyLevel = e.DifficultyLevel,
//                Duration = e.Duration,
//                MuscleName = e.Muscle?.Name
//            };
//        }

//        public async Task<bool> AddAsync(CreateExerciseModel model, string createdBy)
//        {
//            var entity = new Exercise
//            {
//                Title = model.Title,
//                Description = model.Description,
//                DifficultyLevel = model.DifficultyLevel,
//                Duration = model.Duration,
//                MuscleId = model.MuscleId,
//                CreatedBy = createdBy,
//                Access = true
//            };
//            await _context.Exercises.AddAsync(entity);
//            return await _context.SaveChangesAsync() > 0;
//        }

//        public async Task<bool> UpdateAsync(int id, CreateExerciseModel model)
//        {
//            var entity = await _context.Exercises.FindAsync(id);
//            if (entity == null) return false;

//            entity.Title = model.Title;
//            entity.Description = model.Description;
//            entity.DifficultyLevel = model.DifficultyLevel;
//            entity.Duration = model.Duration;
//            entity.MuscleId = model.MuscleId;

//            _context.Exercises.Update(entity);
//            return await _context.SaveChangesAsync() > 0;
//        }

//        public async Task<bool> DeleteAsync(int id)
//        {
//            var entity = await _context.Exercises.FindAsync(id);
//            if (entity == null) return false;

//            _context.Exercises.Remove(entity);
//            return await _context.SaveChangesAsync() > 0;
//        }

//        public async Task<IEnumerable<ExerciseModel>> GetByMuscleIdAsync(int muscleId)
//        {
//            return await _context.Exercises
//                .Where(x => x.MuscleId == muscleId)
//                .Select(e => new ExerciseModel
//                {
//                    ExerciseId = e.ExerciseId,
//                    Title = e.Title,
//                    Description = e.Description,
//                    DifficultyLevel = e.DifficultyLevel,
//                    Duration = e.Duration,
//                    MuscleName = e.Muscle!.Name
//                }).ToListAsync();
//        }
//    }
//}
