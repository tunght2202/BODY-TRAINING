using BODYTRANINGAPI.Repository.WorkoutPlanRepo;
using BODYTRANINGAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BODYTRANINGAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WorkoutPlanController : ControllerBase
    {
        private readonly IWorkoutPlanRepository _repository;

        public WorkoutPlanController(IWorkoutPlanRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var plans = await _repository.GetWorkoutPlansAsync(userId);
            return Ok(plans);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var plan = await _repository.GetWorkoutPlanByIdAsync(id);
            if (plan == null) return NotFound();
            return Ok(plan);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateWorkoutPlanModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _repository.AddWorkoutPlanAsync(userId, model);
            if (!result) return StatusCode(500, "Failed to create workout plan.");
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateWorkoutPlanModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _repository.UpdateWorkoutPlanAsync(id, model);
            if (!result) return NotFound();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repository.DeleteWorkoutPlanAsync(id);
            if (!result) return NotFound();
            return Ok();
        }
    }
}
