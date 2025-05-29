namespace SafeRoute.Contracts.Dtos.Requests;

public class UserRequestDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime RegisterDate { get; set; } = DateTime.Now;
}
