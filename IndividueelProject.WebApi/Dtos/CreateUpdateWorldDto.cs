using System.ComponentModel.DataAnnotations;

namespace IndividueelProject.WebApi.Dtos
{
    public class CreateUpdateWorldDto
    {
        [Required]
        [MaxLength(25, ErrorMessage = "Name cannot exceed 25 characters")]
        [MinLength(1, ErrorMessage = "Name must be at least 1 character")]
        string Name  { get; set; } = null!;
    }
}
