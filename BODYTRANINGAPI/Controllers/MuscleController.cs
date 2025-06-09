using AutoMapper;
using BODYTRANINGAPI.Models;
using BODYTRANINGAPI.Repository.MuscleRepo;
using BODYTRANINGAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BODYTRANINGAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuscleController : ControllerBase
    {
        private readonly IMuscleRepository _muscleRepository;
        private readonly IMapper _mapper;

        public MuscleController(IMuscleRepository muscleRepository
            , IMapper mapper)
        {
            _muscleRepository = muscleRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var muscles = await _muscleRepository.GetAllAsync();
            return Ok(muscles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var muscle = await _muscleRepository.GetByIdAsync(id);
            if (muscle == null) return NotFound();
            return Ok(muscle);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateMuscleViewModel model, IFormFile image)
        {
            if (model == null || string.IsNullOrEmpty(model.Name))
            {
                return BadRequest("Invalid muscle data.");
            }
            var muscle = _mapper.Map<Muscle>(model);
            var imageUrl = await _muscleRepository.PushImage(image);
            muscle.ImageUrl = imageUrl;
            await _muscleRepository.AddAsync(muscle);
            return CreatedAtAction(nameof(GetById), new { id = muscle.MuscleId }, model);
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(int id, [FromBody] Muscle model)
        //{
        //    var existing = await _muscleRepository.GetByIdAsync(id);
        //    if (existing == null) return NotFound();

        //    existing.Name = model.Name;
        //    existing.GroupName = model.GroupName;

        //    _muscleRepository.Update(existing);
        //    await _muscleRepository.SaveChangesAsync();

        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var existing = await _muscleRepository.GetByIdAsync(id);
        //    if (existing == null) return NotFound();

        //    _muscleRepository.Delete(existing);
        //    await _muscleRepository.SaveChangesAsync();

        //    return NoContent();
        //}
    }
}
