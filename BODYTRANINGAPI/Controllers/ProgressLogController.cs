using BODYTRANINGAPI.Models;
using BODYTRANINGAPI.Repository.ProgressLogRepo;
using BODYTRANINGAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BODYTRANINGAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProgressLogController : ControllerBase
    {
        private readonly IProgressLogRepository _progressLogRepository;
        private readonly BODYTRAININGDbContext _context;

        public ProgressLogController(IProgressLogRepository progressLogRepository
            , BODYTRAININGDbContext context)
        {
            _progressLogRepository = progressLogRepository;
            _context = context;
        }

        [HttpPost("log-weight")]
        public async Task<IActionResult> LogStatusBody([FromBody] ProgressLogModel progressLog)
        {
            string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (progressLog == null || string.IsNullOrEmpty(userId))
            {
                return BadRequest("Invalid progress log data.");
            }
            var result = await _progressLogRepository.AddProgressLogAsync(progressLog, userId);
            return Ok(progressLog);
        }

        [HttpGet("weight-history")]
        public async Task<IActionResult> GetWeightHistory()
        {
            string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("UserId is required.");
            }

            var history = await _progressLogRepository.GetWeightHistoryAsync(userId);
            return Ok(history);
        }

        [HttpGet("weight-a-history/{ProgressLogId}")]
        public async Task<IActionResult> GetAWeightHistory(int ProgressLogId)
        {
            if (ProgressLogId == null)
            {
                return BadRequest("ProgressLogId is required.");
            }

            var history = await _progressLogRepository.GetAWeightHistoryAsync(ProgressLogId);
            return Ok(history);
        }

        [HttpPost("add-media")]
        public async Task<IActionResult> AddMedia([FromForm]  int ProgressLogId, [FromForm] List<IFormFile> image)
        {
            if (ProgressLogId == null || image.Count <= 0)
            {
                return BadRequest("Invalid media data.");
            }

             var results = await _progressLogRepository.AddProgressLogMediaAsync(ProgressLogId, image);
            return Ok("Add image successfull");
        }
    }
}
