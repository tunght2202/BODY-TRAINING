using AutoMapper;
using BODYTRANINGAPI.Models;
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
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IMapper _mapper;

        public ExerciseController(IExerciseRepository exerciseRepository
            , IMapper mapper)
        {
            _exerciseRepository = exerciseRepository;
            _mapper = mapper;
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddExerciseAsync([FromForm] AddExerciseViewModel addExerciseViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Ánh xạ từ AddExerciseViewModel sang đối tượng Exercise
            var exercise = _mapper.Map<Exercise>(addExerciseViewModel);

            // Lấy UserId từ Claims để gán cho Exercise
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized("User not found.");
            }
            exercise.UserId = userId;

            // Ánh xạ các ExerciseMuscle và ExerciseMedia từ ViewModel sang đối tượng
            var exerciseMuscles = addExerciseViewModel.ListMuscles;

            // Convert single IFormFile to a List<IFormFile> as required by PushListImage
            var image = addExerciseViewModel.Images;
            var exerciseMedias = await _exerciseRepository.PushListImage(image);

            // Thực hiện thêm Exercise, ExerciseMuscle và ExerciseMedia vào cơ sở dữ liệu
            await _exerciseRepository.AddExerciseAsync(exercise, exerciseMuscles, exerciseMedias);

            return Ok();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<GetExerciseViewModel>> GetExercise(int id)
        {
            var exercise = await _exerciseRepository.GetByIdAsync(id);
            if (exercise == null)
            {
                return NotFound();
            }

            // Ánh xạ từ mô hình Exercise sang ViewModel GetExerciseViewModel
            var exerciseViewModel = _mapper.Map<GetExerciseViewModel>(exercise);
            return Ok(exerciseViewModel);
        }
    }
}
