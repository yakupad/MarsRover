using System;
using System.Collections.Generic;
using System.Text;
using MarsRover.Common.Enums;
using MarsRover.Common.Models;

namespace MarsRover.Core.Service
{
    public interface INavigationService
    {
        /// <summary>
        /// It is used to rotate rover to left
        /// </summary>
        /// <param name="point"></param>
        ///  Enum includes the following elements
        ///     - North
        ///     - East
        ///     - West
        ///     - South
        /// <returns>Method returns current compass point for selected rover</returns>
        CompassPoint TurnLeft(CompassPoint point);

        /// <summary>
        /// It is used to rotate rover to right
        /// </summary>
        /// <param name="point"></param>
        ///  Enum includes the following elements
        ///     - North
        ///     - East
        ///     - West
        ///     - South
        /// <returns>Method returns current compass point for selected rover</returns>
        CompassPoint TurnRight(CompassPoint point);

        /// <summary>
        /// It is used to rover forward
        /// </summary>
        /// <param name="currentLocation"></param>
        ///  Model includes the following elements
        ///     - Position
        ///     - CompassPoint
        /// <returns>Method returns current location for selected rover</returns>
        PositionModel Move(RoverCurrentLocationModel currentLocation);
    }
}
