using System.ComponentModel.DataAnnotations;
namespace IndividueelProject.WebApi.Models
{
    public class ObjectModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int WorldId { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public float PositionX  { get; set; }

        [Required]
        public float PositionY { get; set; }
    }
}
