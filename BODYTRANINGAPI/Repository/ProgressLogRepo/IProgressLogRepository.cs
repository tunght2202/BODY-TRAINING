using BODYTRANINGAPI.Models;
using BODYTRANINGAPI.ViewModels;

namespace BODYTRANINGAPI.Repository.ProgressLogRepo
{
    public interface IProgressLogRepository
    {
        Task<bool> AddProgressLogAsync(ProgressLogModel progressLogModel, string UserId);
        Task<List<GetProgressLogModel>> GetWeightHistoryAsync(string userId);
        Task<GetProgressLogModel> GetAWeightHistoryAsync(int ProgressLogId);
        Task<bool> AddProgressLogMediaAsync(int ProgressLogId, List<IFormFile> listImage);
        
    }
}
