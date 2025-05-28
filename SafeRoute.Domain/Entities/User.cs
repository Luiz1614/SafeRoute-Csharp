using System.Globalization;

namespace SafeRoute.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime RegisterDate { get; set; }
}
