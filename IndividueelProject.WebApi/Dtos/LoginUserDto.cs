using System.ComponentModel.DataAnnotations;

namespace IndividueelProject.WebApi.Dtos
{
    public class LoginUserDto
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid credentials")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Invalid credentials")]
        public string Password { get; set; } = null!;
    }
}
