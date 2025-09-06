namespace Airbnb.Contracts.Models;

public class Property
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal PricePerNight { get; set; }
    public string Location { get; set; } = string.Empty;

    // Relationships
    public string OwnerId { get; set; } = string.Empty;
    public ApplicationUser? Owner { get; set; }
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
