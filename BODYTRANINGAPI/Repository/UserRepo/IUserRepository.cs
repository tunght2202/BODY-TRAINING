using BODYTRANINGAPI.Models;
using Microsoft.AspNetCore.Identity.Data;
using BODYTRANINGAPI.ViewModels;

namespace BODYTRANINGAPI.Repository.UserRepo
{
    public interface IUserRepository
    {
        Task<string> Authencate(LoginRequest loginRequest);
        Task<(bool success, string message)> RegisterRequestAsync(RegisterRequestModel model, IFormFile? image);
        Task<bool> RegisterAccountAsync(VerifyOtpModel model);
        Task<bool> RequestPasswordResetAsync(ForgotPasswordModel model);
        Task<bool> ResetPasswordAsync(ResetPasswordModel model);
        Task<bool> RequestPasswordResetVerifyOtpAsync(VerifyOtpModel model);
        Task<User> GetUserProfile(string UserId);
        Task<bool> UpdateUserProfileRequest(User user, UpdateUserProfileModel model);
        Task<bool> UpdateUserProfile(VerifyOtpModel model, User user);
        Task<User> GetUserById(string userId);
    }
}
