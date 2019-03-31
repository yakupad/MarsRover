using MarsRover.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core.Repository
{
    public interface IPlateauRepository: IBaseRepository
    {
        bool CreatePlateau(PlateauModel plateau);
        PlateauModel GetPlateau(int plateauId);
        bool UpdatePlateau(PlateauModel plateau);
        bool RemovePlateau(int plateauId);
    }
}
 