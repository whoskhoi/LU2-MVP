using System.ComponentModel.DataAnnotations;

namespace IndividueelProject.WebApi.Dtos
{
    public class RegisterUserDto
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = null!;


        [Required]
        [RegularExpression(
            "^(?=.[A-Z])(?=.[a-z])(?=.\\d)(?=.[!@#$%^&()_+\\-=])[A-Za-z\\d!@#$%^&()_+\\-=]{10,}$",
            ErrorMessage = "Password must be at least 10 characters, contain uppercase, lowercase, digit, and special character."
        )]
        public string Password { get; set; } = null!;
    }
}
