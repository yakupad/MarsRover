using System;
using System.Collections.Generic;
using System.Text;
using MarsRover.Common.Enums;
using MarsRover.Common.Models;
using MarsRover.Core.Service;

namespace MarsRover.Service
{
    public class NavigationService : INavigationService
    {
        public CompassPoint TurnLeft(CompassPoint point)
        {
            switch (point)
            {
                case CompassPoint.North:
                    point = CompassPoint.West;
                    break;
                case CompassPoint.East:
                    point = CompassPoint.North;
                    break;
                case CompassPoint.South:
                    point = CompassPoint.East;
                    break;
                case CompassPoint.West:
                    point = CompassPoint.South;
                    break;
            }
            return point;
        }

        public CompassPoint TurnRight(CompassPoint point)
        {
            switch (point)
            {
                case CompassPoint.North:
                    point = CompassPoint.East;
                    break;
                case CompassPoint.East:
                    point = CompassPoint.South;
                    break;
                case CompassPoint.South:
                    point = CompassPoint.West;
                    break;
                case CompassPoint.West:
                    point = CompassPoint.North;
                    break;
            }
            return point;
        }

        public PositionModel Move(RoverCurrentLocationModel currentLocation)
        {
            switch (currentLocation.CompassPoint)
            {
                case CompassPoint.North:
                    currentLocation.Position.Y += 1;
                    break;
                case CompassPoint.West:
                    currentLocation.Position.X -= 1;
                    break;
                case CompassPoint.South:
                    currentLocation.Position.Y -= 1;
                    break;
                case CompassPoint.East:
                    currentLocation.Position.X += 1;
                    break;
            }
            return currentLocation.Position;
        }
    }
}
