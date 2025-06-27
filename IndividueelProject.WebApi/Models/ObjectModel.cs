using System.ComponentModel.DataAnnotations;
namespace IndividueelProject.WebApi.Models
{
    public class ObjectModel
    {
       
        public int Id { get; set; }
        public int WorldId { get; set; }
        public string Type { get; set; }
        public float PositionX  { get; set; }   
        public float PositionY { get; set; }
    }
}
