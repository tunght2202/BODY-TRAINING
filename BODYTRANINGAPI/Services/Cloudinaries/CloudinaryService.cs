using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace BODYTRANINGAPI.Services.Cloudinaries
{
    public class CloudinaryService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryService(IConfiguration configuration)
        {
            var cloudName = configuration["Cloudinary:CloudName"];
            var apiKey = configuration["Cloudinary:ApiKey"];
            var apiSecret = configuration["Cloudinary:ApiSecret"];

            var account = new Account(cloudName, apiKey, apiSecret);
            _cloudinary = new Cloudinary(account);
        }

        public async Task<string> UploadImageAsync(IFormFile file)
        {
            using (var stream = file.OpenReadStream())
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.FileName, stream)
                };

                var uploadResult = await _cloudinary.UploadAsync(uploadParams);
                if (uploadResult == null)
                    return "Upload faile! Please check your API key or connect";

                if (uploadResult.Error != null)
                    return $"error Cloudinary: {uploadResult.Error.Message}";

                return uploadResult.SecureUrl?.ToString() ?? "can't get URL!";

            }
        }
    }
}
