using System.ComponentModel.DataAnnotations;

namespace SafeRoute.Contracts.Dtos.Requests;

public class UserRequestDto
{
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, ErrorMessage = "Name must be at most 200 characters.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    [StringLength(100, ErrorMessage = "Email must be at most 100 characters.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Phone is required.")]
    [Phone(ErrorMessage = "Invalid phone number.")]
    [StringLength(11, ErrorMessage = "Phone must be at most 11 characters.")]
    public string Phone { get; set; }
}
