using System.ComponentModel.DataAnnotations;

namespace IndividueelProject.WebApi.Models
{
    public class WorldModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OwnerId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
