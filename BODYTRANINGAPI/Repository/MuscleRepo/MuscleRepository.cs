using BODYTRANINGAPI.Models;
using BODYTRANINGAPI.Services.Cloudinaries;
using Microsoft.EntityFrameworkCore;
using System;

namespace BODYTRANINGAPI.Repository.MuscleRepo
{
    public class MuscleRepository : IMuscleRepository
    {
        private readonly BODYTRAININGDbContext _context;
        private readonly CloudinaryService _cloudinaryService;

        public MuscleRepository(BODYTRAININGDbContext context
            , CloudinaryService cloudinaryService)
        {
            _context = context;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<IEnumerable<Muscle>> GetAllAsync()
        {
            return await _context.Muscles.ToListAsync();
        }

        public async Task<Muscle> GetByIdAsync(int id)
        {
            return await _context.Muscles.FindAsync(id);
        }

        public async Task<bool> AddAsync(Muscle muscle)
        {
            if (muscle == null)
                throw new ArgumentNullException(nameof(muscle), "Muscle entity cannot be null.");

            try
            {
                await _context.Muscles.AddAsync(muscle);
                var result = await _context.SaveChangesAsync();
                if (result <= 0)
                {
                    throw new Exception("Failed to add muscle to the database.");
                }
                return true;
            }
            catch (Exception ex)
            {
                // Log lỗi ở đây nếu cần, ví dụ: _logger.LogError(ex, "Lỗi khi thêm Muscle");
                Console.WriteLine($"Error adding muscle: {ex.Message}");
                return false;
            }
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
                if (imageUrl == null)
                {
                    throw new Exception("Can't push image");
                }
                return imageUrl;
            }
            catch (Exception ex)
            {
                throw new Exception("Can't push image");
            }
        }

        public Task UpdateAsync(Muscle entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        Task IRepository<Muscle>.AddAsync(Muscle entity)
        {
            return AddAsync(entity);
        }
    }
}
