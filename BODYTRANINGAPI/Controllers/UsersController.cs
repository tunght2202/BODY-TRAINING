using BODYTRANINGAPI.Models;
using BODYTRANINGAPI.Repository.UserRepo;
using BODYTRANINGAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Security.Claims;

namespace BODYTRANINGAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        public UsersController(UserManager<User> userManager, IDistributedCache cache, IConfiguration config
            , IUserRepository userRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;

        }

        [HttpPost("login-account-request")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest loginRequest)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _userRepository.Authencate(loginRequest);
            if (string.IsNullOrEmpty(result))
            {
                return BadRequest("Username or password in correct!");
            }
            return Ok(new { token = result });
        }

        [HttpPost("register-account-request")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterRequest([FromForm] RegisterRequestModel model, IFormFile? Avatar)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var (success, message) = await _userRepository.RegisterRequestAsync(model, Avatar);

            if (!success) return BadRequest(new { message });

            return Ok(new { message });
        }


        [HttpPost("register-account")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAccount([FromBody] VerifyOtpModel model)
        {
            var result = await _userRepository.RegisterAccountAsync(model);
            if (!result) return BadRequest("OTP code is invalid or expired.");

            return Ok(new { message = "Register successfully!" });
        }

        [HttpPost("reset-password-request")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPasswordRequest([FromBody] ForgotPasswordModel model)
        {

            var result = await _userRepository.RequestPasswordResetAsync(model);
            if (!result) return NotFound("Can't find the user.");

            return Ok(new { message = "OTP code has been sent via email." });
        }
        [HttpPost("reset-password-verify-otp")]
        [AllowAnonymous]
        public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtpModel model)
        {

            var result = await _userRepository.RequestPasswordResetVerifyOtpAsync(model);
            if (!result) return BadRequest("OTP code is invalid or expired.");

            return Ok(new { message = "OTP valid. You can reset your password." });
        }
        [HttpPost("reset-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Password is invalid.");
            }
            var result = await _userRepository.ResetPasswordAsync(model);
            if (!result) return BadRequest("Cannot find user.");

            return Ok(new { message = "Password was reset successfully." });
        }
        [HttpGet("user-profile")]
        public async Task<IActionResult> GetUserProfile()
        {
            string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            User user = await _userRepository.GetUserProfile(userId);
            if (user == null) return NotFound();

            return Ok(user);
        }
        [HttpPut("update-userProfile-request")]
        public async Task<IActionResult> UpdateProfileRequest([FromForm] UpdateUserProfileModel model)
        {
            string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            User user = await _userManager.FindByIdAsync(userId);
            if (user == null) return BadRequest("Can't find the user");
            var result = await _userRepository.UpdateUserProfileRequest(user, model);
            if (!result) return BadRequest("Error in information editing!");
            if (model.Email != null && model.Password != null)
            {
                return Ok(new { message = "Please enter email verification code to change email and password." });
            }
            else if (model.Email != null && model.Password == null)
            {
                return Ok(new { message = "Please enter email verification code to change email." });
            }
            else if (model.Email == null && model.Password != null)
            {
                return Ok(new { message = "Please enter email verification code to change password." });
            }

            return Ok(new { message = "Information edited successfully." });
        }
        [HttpPut("update-userProfie")]
        public async Task<IActionResult> UpdateProfile(VerifyOtpModel OTP)
        {
            string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            User user = await _userManager.FindByIdAsync(userId);
            var result = await _userRepository.UpdateUserProfile(OTP, user);
            if (!result) return BadRequest("OTP code is invalid or expired.");

            return Ok(new { message = "Information edited successfully." });
        }


    }
}
