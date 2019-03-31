namespace MarsRover.Common.Models
{
    public class RoverModel
    {
        public int Id { get; set; }
        public RoverCurrentLocationModel CurrentLocation { get; set; }
        public int PlateauId { get; set; }
    }
}
