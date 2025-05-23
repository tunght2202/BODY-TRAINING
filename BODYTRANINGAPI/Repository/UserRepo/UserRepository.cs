using BODYTRANINGAPI.Models;
using BODYTRANINGAPI.Services.Cloudinaries;
using BODYTRANINGAPI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BODYTRANINGAPI.Repository.UserRepo
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IDistributedCache _cache;
        private readonly IConfiguration _config;
        private readonly CloudinaryService _cloudinaryService;
        private readonly BODYTRAININGDbContext _bdtDbContext;
        public UserRepository(UserManager<User> userManager, SignInManager<User> signInManager
            , IConfiguration config, IDistributedCache cache, CloudinaryService cloudinaryService, BODYTRAININGDbContext bdtDbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _cloudinaryService = cloudinaryService;
            _bdtDbContext = bdtDbContext;
        }

        public async Task<string> Authencate(LoginRequest loginRequest)
        {
            var user = await _userManager.FindByEmailAsync(loginRequest.Email);
            if (user == null) return null;
            var result = await _signInManager.PasswordSignInAsync(user, loginRequest.Password, loginRequest.RememberMe, true);
            if (!result.Succeeded)
            {
                return null;
            }
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public Task<(bool success, string message)> RegisterRequestAsync(RegisterRequestModel model, IFormFile? image)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegisterAccountAsync(VerifyOtpModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RequestPasswordResetAsync(ForgotPasswordModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ResetPasswordAsync(ResetPasswordModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> VerifyOtpAsync(VerifyOtpModel model)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserProfile(string UserId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUserProfileRequest(User user, UpdateUserProfileModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUserProfile(VerifyOtpModel model, User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserById(string userId)
        {
            throw new NotImplementedException();
        }
    }
    {
    }
}
