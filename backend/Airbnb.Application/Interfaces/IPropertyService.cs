using Airbnb.Contracts.Models;

namespace Airbnb.Application.Interfaces;

public interface IPropertyService
{
    /// <summary>
    /// Creates a new property listing
    /// </summary>
    /// <param name="request">Property creation details</param>
    /// <param name="ownerId">Owner user identifier</param>
    /// <returns>Created property information</returns>
    Task<PropertyResponse> CreatePropertyAsync(CreatePropertyRequest request, string ownerId);

    /// <summary>
    /// Updates an existing property
    /// </summary>
    /// <param name="propertyId">Property identifier</param>
    /// <param name="request">Updated property data</param>
    /// <param name="ownerId">Owner user identifier for authorization</param>
    /// <returns>Updated property information</returns>
    Task<PropertyResponse> UpdatePropertyAsync(int propertyId, UpdatePropertyRequest request, string ownerId);

    /// <summary>
    /// Deletes a property listing
    /// </summary>
    /// <param name="propertyId">Property identifier</param>
    /// <param name="ownerId">Owner user identifier for authorization</param>
    /// <returns>Deletion result</returns>
    Task<bool> DeletePropertyAsync(int propertyId, string ownerId);

    /// <summary>
    /// Gets a specific property by ID
    /// </summary>
    /// <param name="propertyId">Property identifier</param>
    /// <returns>Property details if found</returns>
    Task<PropertyResponse?> GetPropertyByIdAsync(int propertyId);

    /// <summary>
    /// Lists properties with optional filtering and pagination
    /// </summary>
    /// <param name="request">Search and filter criteria</param>
    /// <returns>List of properties matching criteria</returns>
    Task<PropertyListResponse> ListPropertiesAsync(PropertySearchRequest request);

    /// <summary>
    /// Gets all properties owned by a specific user
    /// </summary>
    /// <param name="ownerId">Owner user identifier</param>
    /// <returns>List of properties owned by the user</returns>
    Task<List<PropertyResponse>> GetPropertiesByOwnerAsync(string ownerId);

    /// <summary>
    /// Checks if a property is available for booking in a date range
    /// </summary>
    /// <param name="propertyId">Property identifier</param>
    /// <param name="startDate">Check-in date</param>
    /// <param name="endDate">Check-out date</param>
    /// <returns>True if available, false if booked</returns>
    Task<bool> IsPropertyAvailableAsync(int propertyId, DateTime startDate, DateTime endDate);
}

// DTOs for Property Service
public class CreatePropertyRequest
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal PricePerNight { get; set; }
    public string Location { get; set; } = string.Empty;
    public int MaxGuests { get; set; }
    public int Bedrooms { get; set; }
    public int Bathrooms { get; set; }
    public List<string> Amenities { get; set; } = new();
    public List<string> ImageUrls { get; set; } = new();
}

public class UpdatePropertyRequest
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal PricePerNight { get; set; }
    public string Location { get; set; } = string.Empty;
    public int MaxGuests { get; set; }
    public int Bedrooms { get; set; }
    public int Bathrooms { get; set; }
    public List<string> Amenities { get; set; } = new();
    public List<string> ImageUrls { get; set; } = new();
}

public class PropertyResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal PricePerNight { get; set; }
    public string Location { get; set; } = string.Empty;
    public int MaxGuests { get; set; }
    public int Bedrooms { get; set; }
    public int Bathrooms { get; set; }
    public List<string> Amenities { get; set; } = new();
    public List<string> ImageUrls { get; set; } = new();
    public string OwnerId { get; set; } = string.Empty;
    public string OwnerName { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public double AverageRating { get; set; }
    public int TotalReviews { get; set; }
}

public class PropertySearchRequest
{
    public string? Location { get; set; }
    public DateTime? CheckInDate { get; set; }
    public DateTime? CheckOutDate { get; set; }
    public int? Guests { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public int? MinBedrooms { get; set; }
    public int? MinBathrooms { get; set; }
    public List<string> Amenities { get; set; } = new();
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string SortBy { get; set; } = "CreatedAt"; // CreatedAt, Price, Rating
    public bool SortDescending { get; set; } = true;
}

public class PropertyListResponse
{
    public List<PropertyResponse> Properties { get; set; } = new();
    public int TotalCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public bool HasNextPage { get; set; }
    public bool HasPreviousPage { get; set; }
}
