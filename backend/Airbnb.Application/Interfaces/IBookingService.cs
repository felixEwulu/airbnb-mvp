using Airbnb.Contracts.Models;

namespace Airbnb.Application.Interfaces;

public interface IBookingService
{
    /// <summary>
    /// Creates a new booking for a property
    /// </summary>
    /// <param name="request">Booking creation details</param>
    /// <param name="userId">User making the booking</param>
    /// <returns>Created booking information</returns>
    Task<BookingResponse> CreateBookingAsync(CreateBookingRequest request, string userId);

    /// <summary>
    /// Cancels an existing booking
    /// </summary>
    /// <param name="bookingId">Booking identifier</param>
    /// <param name="userId">User canceling the booking</param>
    /// <param name="cancellationReason">Reason for cancellation</param>
    /// <returns>Cancellation result</returns>
    Task<BookingCancellationResponse> CancelBookingAsync(int bookingId, string userId, string cancellationReason);

    /// <summary>
    /// Gets detailed information about a specific booking
    /// </summary>
    /// <param name="bookingId">Booking identifier</param>
    /// <param name="userId">User requesting the booking details</param>
    /// <returns>Booking details if authorized</returns>
    Task<BookingResponse?> GetBookingDetailsAsync(int bookingId, string userId);

    /// <summary>
    /// Gets all bookings for a specific user
    /// </summary>
    /// <param name="userId">User identifier</param>
    /// <param name="status">Optional status filter</param>
    /// <returns>List of user's bookings</returns>
    Task<List<BookingResponse>> GetUserBookingsAsync(string userId, BookingStatus? status = null);

    /// <summary>
    /// Gets all bookings for properties owned by a user
    /// </summary>
    /// <param name="ownerId">Property owner identifier</param>
    /// <param name="status">Optional status filter</param>
    /// <returns>List of bookings for owner's properties</returns>
    Task<List<BookingResponse>> GetOwnerBookingsAsync(string ownerId, BookingStatus? status = null);

    /// <summary>
    /// Updates booking status (for property owners or system)
    /// </summary>
    /// <param name="bookingId">Booking identifier</param>
    /// <param name="newStatus">New booking status</param>
    /// <param name="userId">User making the update</param>
    /// <returns>Updated booking information</returns>
    Task<BookingResponse> UpdateBookingStatusAsync(int bookingId, BookingStatus newStatus, string userId);

    /// <summary>
    /// Checks for booking conflicts with existing bookings
    /// </summary>
    /// <param name="propertyId">Property identifier</param>
    /// <param name="startDate">Proposed start date</param>
    /// <param name="endDate">Proposed end date</param>
    /// <param name="excludeBookingId">Booking to exclude from conflict check (for updates)</param>
    /// <returns>True if conflict exists</returns>
    Task<bool> HasBookingConflictAsync(int propertyId, DateTime startDate, DateTime endDate, int? excludeBookingId = null);

    /// <summary>
    /// Gets booking statistics for a property
    /// </summary>
    /// <param name="propertyId">Property identifier</param>
    /// <returns>Booking statistics</returns>
    Task<BookingStatsResponse> GetPropertyBookingStatsAsync(int propertyId);
}

// Enums
public enum BookingStatus
{
    Pending = 0,
    Confirmed = 1,
    CheckedIn = 2,
    CheckedOut = 3,
    Cancelled = 4,
    Completed = 5
}

// DTOs for Booking Service
public class CreateBookingRequest
{
    public int PropertyId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int NumberOfGuests { get; set; }
    public string SpecialRequests { get; set; } = string.Empty;
}

public class BookingResponse
{
    public int Id { get; set; }
    public int PropertyId { get; set; }
    public string PropertyTitle { get; set; } = string.Empty;
    public string PropertyLocation { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string UserEmail { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int NumberOfGuests { get; set; }
    public int NumberOfNights { get; set; }
    public decimal PricePerNight { get; set; }
    public decimal TotalPrice { get; set; }
    public BookingStatus Status { get; set; }
    public string SpecialRequests { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime? CancelledAt { get; set; }
    public string? CancellationReason { get; set; }
}

public class BookingCancellationResponse
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; } = string.Empty;
    public decimal RefundAmount { get; set; }
    public DateTime? RefundProcessedAt { get; set; }
    public List<string> Errors { get; set; } = new();
}

public class BookingStatsResponse
{
    public int TotalBookings { get; set; }
    public int ActiveBookings { get; set; }
    public int CompletedBookings { get; set; }
    public int CancelledBookings { get; set; }
    public decimal TotalRevenue { get; set; }
    public double AverageBookingValue { get; set; }
    public double OccupancyRate { get; set; }
}
