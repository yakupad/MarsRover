using MarsRover.Common.Enums;
using MarsRover.Common.Models;
using MarsRover.Core.Service;

namespace MarsRover.Controllers
{
    public class RoverController
    {
        private readonly IRoverService _roverService;
        private readonly INavigationService _navigationService;
        private readonly IPlateauService _plateauService;
        public RoverController(IRoverService roverService, INavigationService navigationService, IPlateauService plateauService)
        {
            _roverService = roverService;
            _navigationService = navigationService;
            _plateauService = plateauService;
        }

        public int AddRover(int x, int y, CompassPoint compassPoint, int plateauId)
        {
            var plateauCoordinatesCheckResult = CheckPlateauCoordinatesForRover(plateauId, x , y);
            if (!plateauCoordinatesCheckResult)
            {
                throw new System.Exception("ERR201: Rover coordinates cannot be outside the plateau coordinates");
            }

            var newRoverId = _roverService.GetNewRoverId();
            RoverModel newRover = new RoverModel
            {
                Id = newRoverId,
                CurrentLocation = new RoverCurrentLocationModel
                {
                    Position = new PositionModel
                    {
                        X = x,
                        Y = y
                    },
                    CompassPoint = compassPoint
                },
                PlateauId = plateauId
            };

            return _roverService.CreateRover(newRover);
        }

        public bool Navigate(int roverId, Move moveRequested)
        {
            var rover = _roverService.ReadRover(roverId);
            switch (moveRequested)
            {
                case Move.Forward:
                    rover.CurrentLocation.Position = _navigationService.Move(rover.CurrentLocation);
                    break;
                case Move.TurnLeft:
                    rover.CurrentLocation.CompassPoint = _navigationService.TurnLeft(rover.CurrentLocation.CompassPoint);
                    break;
                case Move.TurnRight:
                    rover.CurrentLocation.CompassPoint = _navigationService.TurnRight(rover.CurrentLocation.CompassPoint);
                    break;
            }

            var plateauCoordinatesCheckResult = CheckPlateauCoordinatesForRover(rover.PlateauId, rover.CurrentLocation.Position.X, rover.CurrentLocation.Position.Y);
            if (!plateauCoordinatesCheckResult)
            {
                throw new System.Exception("ERR201: rover coordinates cannot be outside the plateau coordinates");
            }

            var result = _roverService.UpdateRover(rover);
            if (!result)
            {
                throw new System.Exception("ERR202: There was a problem updating the rover location.");
            }

            return result;
        }

        public string GetRoverCurrentLocationMessage(int roverId)
        {
            var rover = _roverService.ReadRover(roverId);

            return $"{rover.CurrentLocation.Position.X} {rover.CurrentLocation.Position.Y} {(char)rover.CurrentLocation.CompassPoint}";
        }

        private bool CheckPlateauCoordinatesForRover(int plateauId, int x, int y)
        {
            var plateauRecord = _plateauService.ReadPlateau(plateauId);

            return plateauRecord.Width >= x && plateauRecord.Height >= y;
        }
    }
}
