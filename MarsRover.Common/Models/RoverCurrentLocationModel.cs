using MarsRover.Common.Enums;

namespace MarsRover.Common.Models
{
    public class RoverCurrentLocationModel
    {
        public PositionModel Position { get; set; }
        public CompassPoint CompassPoint { get; set; }
    }
}
