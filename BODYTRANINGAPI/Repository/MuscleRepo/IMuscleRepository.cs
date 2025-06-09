using BODYTRANINGAPI.Models;

namespace BODYTRANINGAPI.Repository.MuscleRepo
{
    public interface IMuscleRepository : IRepository<Muscle>
    {
        Task<bool> AddAsync(Muscle muscle);
        Task<string> PushImage(IFormFile image);

    }

}
