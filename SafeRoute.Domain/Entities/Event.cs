namespace SafeRoute.Domain.Entities;

public class Event
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public DateTime EventTime { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public int RiskLevel { get; set; }
}
