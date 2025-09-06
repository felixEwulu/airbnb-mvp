using Microsoft.AspNetCore.Identity;

namespace Airbnb.Contracts.Models;

public class ApplicationUser : IdentityUser
{
    // Add extra fields if you like
    public string? FullName { get; set; }
}
