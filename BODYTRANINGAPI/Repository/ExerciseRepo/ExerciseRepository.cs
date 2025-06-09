using BODYTRANINGAPI.Models;
using BODYTRANINGAPI.Services.Cloudinaries;
using BODYTRANINGAPI.ViewModels;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace BODYTRANINGAPI.Repository.ExerciseRepo
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly BODYTRAININGDbContext _context;
        private readonly CloudinaryService _cloudinaryService;

        public ExerciseRepository(BODYTRAININGDbContext context
            , CloudinaryService cloudinaryService)
        {
            _context = context;
            _cloudinaryService = cloudinaryService;
        }

        // Triển khai các phương thức cơ bản từ IRepository<Exercise>
        public async Task<IEnumerable<Exercise>> GetAllAsync()
        {
            return await _context.Exercises
                .Where(e => (e.IsDeleted == false) && (e.Access == true))
                .ToListAsync();
        }

        // Triển khai các phương thức chuyên biệt từ IExerciseRepository
        public async Task<IEnumerable<Exercise>> GetExercisesByTitleByUserAsync(string exerciseTitle)
        {
            return await _context.Exercises
                .Where(e => e.Title.Equals(exerciseTitle, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();
        }

        public async Task<IEnumerable<Exercise>> GetExercisesByMuscleByUserAsync(int muscleId)
        {
            return await _context.Exercises
                .Include(x => x.ExerciseMuscles)
                .ThenInclude(em => em.Muscle)
                .Where(e => e.ExerciseMuscles.Any(em => em.MuscleId == muscleId))
                .ToListAsync();
        }

        public async Task<IEnumerable<Exercise>> GetExercisesByDifficultLevelByUserAsync(string difficultLevel)
        {
            return await _context.Exercises
                .Where(e => e.DifficultyLevel.Equals(difficultLevel))
                .ToListAsync();
        }
        public async Task<IEnumerable<Exercise>> GetAllByUserAsync(string userId)
        {
            return await _context.Exercises
                .Where(e => (e.UserId == userId) && (e.IsDeleted == false))
                .ToListAsync();
        }

        public async Task<Exercise> GetByIdAsync(int id)
        {
            return await _context.Exercises.FindAsync(id);
        }

        public async Task AddAsync(Exercise entity)
        {
            await _context.Exercises.AddAsync(entity);
            await SaveAsync();
        }

        public async Task AddExerciseAsync(Exercise exercise, List<int> muscles, List<String> media)
        {
            // Thêm Exercise vào cơ sở dữ liệu
            await _context.Exercises.AddAsync(exercise);
            await _context.SaveChangesAsync();

            // Thêm ExerciseMuscle liên quan đến Exercise
            foreach (var muscle in muscles)
            {
                var exerciseMuscle = new ExerciseMuscle
                {
                    ExerciseId = exercise.ExerciseId,
                    MuscleId = muscle
                };
                _context.ExerciseMuscles.Add(exerciseMuscle);
            }

            // Thêm ExerciseMedia liên quan đến Exercise
            foreach (var m in media)
            {
                var exerciseMedia = new ExerciseMedia
                {
                    Uri = m,
                    ExerciselId = exercise.ExerciseId
                };
                _context.ExerciseMedia.Add(exerciseMedia);
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Exercise entity)
        {
            _context.Exercises.Update(entity);
            await SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Exercises.FindAsync(id);
            if (entity != null)
            {
                _context.Exercises.Remove(entity);
                await SaveAsync();
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<string> PushImage(IFormFile image)
        {
            try
            {
                string imageUrl = null;
                if (image != null)
                {
                    imageUrl = await _cloudinaryService.UploadImageAsync(image);
                }
                if(imageUrl == null)
                {
                    throw new Exception("Can't push image");
                }
                return imageUrl;
            }
            catch(Exception ex)
            {
                throw new Exception("Can't push image");
            }
        }

        public async Task<List<string>> PushListImage(List<IFormFile> listImage)
        {
            try
            {
                if (!(listImage.Count > 0))
                {
                    throw new Exception("Please add image");
                }
                List<string> imageUrls = new List<string>();
                foreach (var image in listImage)
                {
                    if (image == null)
                    {
                        throw new Exception("Please add image");
                    }

                    string imageUrl = null;
                    if (image != null)
                    {
                        imageUrl = await _cloudinaryService.UploadImageAsync(image);
                    }
                    if (imageUrl == null)
                    {
                        throw new Exception("Can't push image");
                    }
                     imageUrls.Add(imageUrl);
                }
                if (imageUrls.Count == 0)
                {
                    throw new Exception("Can't push image");
                }
                return imageUrls;

            }
            catch (Exception ex)
            {
                throw new Exception("Can't push image");
            }
        }
    }
}
