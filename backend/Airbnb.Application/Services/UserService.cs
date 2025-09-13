using Airbnb.Application.Interfaces;
using Airbnb.Contracts.Models;
using Airbnb.Domain.Repositories;

namespace Airbnb.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<UserRegistrationResponse> RegisterAsync(UserRegistrationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<UserLoginResponse> LoginAsync(UserLoginRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<UserProfileResponse> GetProfileAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserProfileResponse> UpdateProfileAsync(string userId, UpdateUserProfileRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser?> GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser?> GetUserByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}