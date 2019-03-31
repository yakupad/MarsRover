using MarsRover.Common.Enums;
using MarsRover.Common.Models;

namespace MarsRover.Core.Service
{
    public interface IRoverService: IBaseService
    {
        /// <summary>
        /// It is used to create new rover
        /// </summary>
        /// <param name="rover"></param>
        ///  Model includes the following elements
        ///     - Id
        ///     - CurrentLocation
        ///     - PlateauId
        /// <returns>Method returns new plateau id</returns>
        int CreateRover(RoverModel rover);

        /// <summary>
        /// It is used to get rover by roverId
        /// </summary>
        /// <param name="roverId"></param>
        /// <returns>Method returns plateau model</returns>
        RoverModel ReadRover(int roverId);

        /// <summary>
        /// It is used to update rover
        /// </summary>
        /// <param name="rover"></param>
        ///  Model includes the following elements
        ///     - Id
        ///     - CurrentLocation
        ///     - PlateauId
        /// <returns>Method returns true and false</returns>
        bool UpdateRover(RoverModel rover);

        /// <summary>
        /// It is used to rover delete
        /// </summary>
        /// <param name="roverId"></param>
        /// <returns>Method returns true and false</returns>
        bool DeleteRover(int roverId);

        /// <summary>
        /// It is used to get new id for new rover record 
        /// </summary>
        /// <returns>Method returns new id for new rover record</returns>
        int GetNewRoverId();
    }

}
