using System.ComponentModel.DataAnnotations;

namespace IndividueelProject.WebApi.Models
{
    public class WorldModel
    {
        
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; }
    }
}
