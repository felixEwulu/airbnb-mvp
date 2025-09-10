using Airbnb.Contracts.Models;

namespace Airbnb.Application.Interfaces;

public interface IUserService
{
    /// <summary>
    /// Registers a new user in the system
    /// </summary>
    /// <param name="request">User registration details</param>
    /// <returns>Registration result with user information</returns>
    Task<UserRegistrationResponse> RegisterAsync(UserRegistrationRequest request);

    /// <summary>
    /// Authenticates user and returns login information
    /// </summary>
    /// <param name="request">Login credentials</param>
    /// <returns>Login result with authentication token</returns>
    Task<UserLoginResponse> LoginAsync(UserLoginRequest request);

    /// <summary>
    /// Retrieves user profile information
    /// </summary>
    /// <param name="userId">User identifier</param>
    /// <returns>User profile details</returns>
    Task<UserProfileResponse> GetProfileAsync(string userId);

    /// <summary>
    /// Updates user profile information
    /// </summary>
    /// <param name="userId">User identifier</param>
    /// <param name="request">Updated profile data</param>
    /// <returns>Updated user profile</returns>
    Task<UserProfileResponse> UpdateProfileAsync(string userId, UpdateUserProfileRequest request);

    /// <summary>
    /// Gets user by email address
    /// </summary>
    /// <param name="email">User email</param>
    /// <returns>User information if found</returns>
    Task<ApplicationUser?> GetUserByEmailAsync(string email);

    /// <summary>
    /// Gets user by user ID
    /// </summary>
    /// <param name="userId">User identifier</param>
    /// <returns>User information if found</returns>
    Task<ApplicationUser?> GetUserByIdAsync(string userId);
}

// DTOs for User Service
public class UserRegistrationRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
}

public class UserRegistrationResponse
{
    public bool IsSuccess { get; set; }
    public string UserId { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public List<string> Errors { get; set; } = new();
}

public class UserLoginRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool RememberMe { get; set; }
}

public class UserLoginResponse
{
    public bool IsSuccess { get; set; }
    public string UserId { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public DateTime TokenExpiry { get; set; }
    public string Message { get; set; } = string.Empty;
    public List<string> Errors { get; set; } = new();
}

public class UserProfileResponse
{
    public string UserId { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public int TotalBookings { get; set; }
    public int TotalProperties { get; set; }
}

public class UpdateUserProfileRequest
{
    public string FullName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
}
