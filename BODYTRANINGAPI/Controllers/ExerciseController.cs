using BODYTRANINGAPI.Repository.ExerciseRepo;
using BODYTRANINGAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BODYTRANINGAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseRepository _repository;

        public ExerciseController(IExerciseRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var exercises = await _repository.GetAllAsync();
            return Ok(exercises);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var exercise = await _repository.GetByIdAsync(id);
            if (exercise == null) return NotFound();
            return Ok(exercise);
        }

        [HttpGet("muscle/{muscleId}")]
        public async Task<IActionResult> GetByMuscleId(int muscleId)
        {
            var exercises = await _repository.GetByMuscleIdAsync(muscleId);
            return Ok(exercises);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateExerciseModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var createdBy = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _repository.AddAsync(model, createdBy);
            if (!result) return StatusCode(500, "Failed to create exercise.");
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateExerciseModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _repository.UpdateAsync(id, model);
            if (!result) return NotFound();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repository.DeleteAsync(id);
            if (!result) return NotFound();
            return Ok();
        }
    }
}
