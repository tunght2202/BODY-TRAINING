using BODYTRANINGAPI.Repository.MealPlanRepo;
using BODYTRANINGAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BODYTRANINGAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MealPlanController : ControllerBase
    {
        private readonly IMealPlanRepository _repository;

        public MealPlanController(IMealPlanRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var meals = await _repository.GetMealPlansAsync(userId);
            return Ok(meals);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var meal = await _repository.GetMealPlanByIdAsync(id);
            if (meal == null) return NotFound();
            return Ok(meal);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMealPlanModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _repository.AddMealPlanAsync(userId, model);
            if (!result) return StatusCode(500, "Failed to create meal plan.");
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateMealPlanModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _repository.UpdateMealPlanAsync(id, model);
            if (!result) return NotFound();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repository.DeleteMealPlanAsync(id);
            if (!result) return NotFound();
            return Ok();
        }
    }
}
