namespace Airbnb.Application.Interfaces;

public interface IPaymentService
{
    /// <summary>
    /// Processes a payment for a booking
    /// </summary>
    /// <param name="request">Payment processing details</param>
    /// <returns>Payment processing result</returns>
    Task<PaymentResponse> MakePaymentAsync(PaymentRequest request);

    /// <summary>
    /// Gets the status of a specific payment
    /// </summary>
    /// <param name="paymentId">Payment identifier</param>
    /// <param name="userId">User requesting payment status</param>
    /// <returns>Payment status information</returns>
    Task<PaymentStatusResponse?> GetPaymentStatusAsync(int paymentId, string userId);

    /// <summary>
    /// Gets all payments for a specific user
    /// </summary>
    /// <param name="userId">User identifier</param>
    /// <param name="status">Optional status filter</param>
    /// <returns>List of user's payments</returns>
    Task<List<PaymentResponse>> GetUserPaymentsAsync(string userId, PaymentStatus? status = null);

    /// <summary>
    /// Gets all payments for bookings of properties owned by a user
    /// </summary>
    /// <param name="ownerId">Property owner identifier</param>
    /// <param name="status">Optional status filter</param>
    /// <returns>List of payments for owner's properties</returns>
    Task<List<PaymentResponse>> GetOwnerPaymentsAsync(string ownerId, PaymentStatus? status = null);

    /// <summary>
    /// Processes a refund for a cancelled booking
    /// </summary>
    /// <param name="request">Refund processing details</param>
    /// <returns>Refund processing result</returns>
    Task<RefundResponse> ProcessRefundAsync(RefundRequest request);

    /// <summary>
    /// Gets payment details by booking ID
    /// </summary>
    /// <param name="bookingId">Booking identifier</param>
    /// <param name="userId">User requesting payment details</param>
    /// <returns>Payment details if found and authorized</returns>
    Task<PaymentResponse?> GetPaymentByBookingIdAsync(int bookingId, string userId);

    /// <summary>
    /// Validates payment method before processing
    /// </summary>
    /// <param name="paymentMethodId">Payment method identifier</param>
    /// <param name="userId">User identifier</param>
    /// <returns>True if payment method is valid</returns>
    Task<bool> ValidatePaymentMethodAsync(string paymentMethodId, string userId);

    /// <summary>
    /// Gets payment statistics for a property owner
    /// </summary>
    /// <param name="ownerId">Property owner identifier</param>
    /// <param name="startDate">Statistics start date</param>
    /// <param name="endDate">Statistics end date</param>
    /// <returns>Payment statistics</returns>
    Task<PaymentStatsResponse> GetPaymentStatsAsync(string ownerId, DateTime startDate, DateTime endDate);
}

// Enums
public enum PaymentStatus
{
    Pending = 0,
    Processing = 1,
    Completed = 2,
    Failed = 3,
    Cancelled = 4,
    Refunded = 5,
    PartiallyRefunded = 6
}

public enum PaymentMethod
{
    CreditCard = 0,
    DebitCard = 1,
    PayPal = 2,
    BankTransfer = 3,
    ApplePay = 4,
    GooglePay = 5
}

// DTOs for Payment Service
public class PaymentRequest
{
    public int BookingId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string Currency { get; set; } = "USD";
    public PaymentMethod PaymentMethod { get; set; }
    public string PaymentMethodId { get; set; } = string.Empty; // External payment provider ID
    public string Description { get; set; } = string.Empty;
    public Dictionary<string, string> Metadata { get; set; } = new();
}

public class PaymentResponse
{
    public int Id { get; set; }
    public int BookingId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string Currency { get; set; } = string.Empty;
    public PaymentMethod PaymentMethod { get; set; }
    public PaymentStatus Status { get; set; }
    public string TransactionId { get; set; } = string.Empty; // External payment provider transaction ID
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime? ProcessedAt { get; set; }
    public string? FailureReason { get; set; }
    public Dictionary<string, string> Metadata { get; set; } = new();
}

public class PaymentStatusResponse
{
    public int PaymentId { get; set; }
    public PaymentStatus Status { get; set; }
    public string StatusDescription { get; set; } = string.Empty;
    public DateTime LastUpdated { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; } = string.Empty;
    public string? FailureReason { get; set; }
    public bool CanRefund { get; set; }
    public decimal RefundableAmount { get; set; }
}

public class RefundRequest
{
    public int PaymentId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public decimal RefundAmount { get; set; }
    public string Reason { get; set; } = string.Empty;
    public bool IsPartialRefund { get; set; }
}

public class RefundResponse
{
    public bool IsSuccess { get; set; }
    public int RefundId { get; set; }
    public decimal RefundAmount { get; set; }
    public string Currency { get; set; } = string.Empty;
    public string RefundTransactionId { get; set; } = string.Empty;
    public DateTime ProcessedAt { get; set; }
    public string Message { get; set; } = string.Empty;
    public List<string> Errors { get; set; } = new();
}

public class PaymentStatsResponse
{
    public decimal TotalRevenue { get; set; }
    public decimal TotalRefunds { get; set; }
    public decimal NetRevenue { get; set; }
    public int TotalTransactions { get; set; }
    public int SuccessfulTransactions { get; set; }
    public int FailedTransactions { get; set; }
    public int RefundedTransactions { get; set; }
    public double SuccessRate { get; set; }
    public double AverageTransactionValue { get; set; }
    public Dictionary<PaymentMethod, int> PaymentMethodBreakdown { get; set; } = new();
    public Dictionary<string, decimal> MonthlyRevenue { get; set; } = new();
}
