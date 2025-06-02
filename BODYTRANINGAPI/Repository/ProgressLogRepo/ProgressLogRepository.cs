using BODYTRANINGAPI.Models;
using BODYTRANINGAPI.Services.Cloudinaries;
using BODYTRANINGAPI.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BODYTRANINGAPI.Repository.ProgressLogRepo
{
    public class ProgressLogRepository : IProgressLogRepository
    {
        private readonly BODYTRAININGDbContext _context;
        private readonly CloudinaryService _cloudinaryService;

        public ProgressLogRepository(BODYTRAININGDbContext context
            , CloudinaryService cloudinaryService)
        {
            _context = context;
            _cloudinaryService = cloudinaryService;
        }
        public async Task<bool> AddProgressLogAsync(ProgressLogModel progressLogModel, string UserId)
        {

            var bmi = CalculateBMI(progressLogModel.Weight, progressLogModel.Height);
            var progressLog = new ProgressLog
            {
                LogDate = DateOnly.FromDateTime(DateTime.UtcNow),
                Height = progressLogModel.Height,
                Weight = progressLogModel.Weight,
                CaloriesBurned = progressLogModel.CaloriesBurned,
                CaloriesConsumed = progressLogModel.CaloriesConsumed,
                UserId = UserId,
                Bmi = bmi
            };
            await _context.ProgressLogs.AddAsync(progressLog);
            var result = await _context.SaveChangesAsync();
            if(result > 0)
            {
               return true;
            }
            return false;
        }

        public async Task<List<GetProgressLogModel>> GetWeightHistoryAsync(string userId)
        {
            var progressLog = await _context.ProgressLogs
                .Where(pl => pl.UserId == userId)
                .OrderBy(pl => pl.LogDate)
                .ToListAsync();
            var progressLogModels = progressLog.Select(pl => new GetProgressLogModel
            {
                LogId = pl.LogId,
                LogDate = pl.LogDate,
                Weight = pl.Weight,
                Height = pl.Height,
                BMI = pl.Bmi,
                CaloriesBurned = pl.CaloriesBurned,
                CaloriesConsumed = pl.CaloriesConsumed
            }).ToList();
            if (progressLogModels.Count == 0)
            {
                return null;
            }
            return progressLogModels;
        }

        public async Task<bool> AddProgressLogMediaAsync(int ProgressLogId, List<IFormFile> listImage)
        {
            var media = new List<ProgressLogsMedias>();
            if (listImage == null || listImage.Count == 0)
            {
                return false;
            }
            foreach (var image in listImage)
            {
                if (image.Length == 0)
                {
                    return false;
                }
                var mediaItem = new ProgressLogsMedias
                {
                    ProgressLogId = ProgressLogId,
                    DateCreated = DateTime.UtcNow
                };
                mediaItem.MediaUrl = await _cloudinaryService.UploadImageAsync(image);
                media.Add(mediaItem);
            }
            await _context.ProgressLogsMedias.AddRangeAsync(media);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        private decimal? CalculateBMI(decimal? weight, decimal? height)
        {
            if (weight == null || height == null || height <= 0)
            {
                return 0; // Return 0 or handle as needed
            }
            var heightInMeters = height / 100;
            return weight / (heightInMeters * heightInMeters);
        }

        public async Task<GetProgressLogModel> GetAWeightHistoryAsync(int ProgressLogId)
        {
            var progressLog = await _context.ProgressLogs
                .FirstOrDefaultAsync(pl => pl.LogId == ProgressLogId);

            var progressLogModels = new GetProgressLogModel() 
            {
                LogId = progressLog.LogId,
                LogDate = progressLog.LogDate,
                Weight = progressLog.Weight,
                Height = progressLog.Height,
                BMI = progressLog.Bmi,
                CaloriesBurned = progressLog.CaloriesBurned,
                CaloriesConsumed = progressLog.CaloriesConsumed 
            };

            if (progressLogModels == null)
            {
                return null;
            }
            return progressLogModels;
        }
    }
}
