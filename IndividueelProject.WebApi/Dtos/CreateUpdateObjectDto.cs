using System.ComponentModel.DataAnnotations;

namespace IndividueelProject.WebApi.Dtos
{
    public class CreateUpdateObjectDto
    {
        [Required]
        public int WorldId { get; set; }

        [Required]
        public string Type { get; set; } = null!;

        [Required]
        public float PositionX { get; set; }

        [Required]
        public float PositionY { get; set; } 
    }
}
