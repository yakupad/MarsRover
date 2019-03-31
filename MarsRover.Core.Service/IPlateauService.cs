using MarsRover.Common.Enums;
using MarsRover.Common.Models;

namespace MarsRover.Core.Service
{
    public interface IPlateauService: IBaseService
    {
        /// <summary>
        /// It is used to create new plateau
        /// </summary>
        /// <param name="plateau"></param>
        ///  Model includes the following elements
        ///     - Id
        ///     - Width
        ///     - Height
        /// <returns>Method returns new plateau id</returns>
        int CreatePlateau(PlateauModel plateau);

        /// <summary>
        /// It is used to get plateau by plateauId
        /// </summary>
        /// <param name="plateauId"></param>
        /// <returns>Method returns plateau model</returns>
        PlateauModel ReadPlateau(int plateauId);

        /// <summary>
        /// It is used to update plateau
        /// </summary>
        /// <param name="plateau"></param>
        ///  Model includes the following elements
        ///     - Id
        ///     - Width
        ///     - Height
        /// <returns>Method returns true and false</returns>
        bool UpdatePlateau(PlateauModel plateau);

        /// <summary>
        /// It is used to plateau delete
        /// </summary>
        /// <param name="plateauId"></param>
        /// <returns>Method returns true and false</returns>
        bool DeletePlateau(int plateauId);

        /// <summary>
        /// It is used to get new id for new plateau record 
        /// </summary>
        /// <returns>Method returns new id for new plateau record</returns>
        int GetNewPlateauId();
    }
}
