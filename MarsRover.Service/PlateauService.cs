using System.Collections.Generic;
using System.Linq;
using MarsRover.Common.Models;
using MarsRover.Core.Service;

namespace MarsRover.Service
{
    public class PlateauService : BaseService, IPlateauService
    {
        List<PlateauModel> plateauEntity = new List<PlateauModel>();

        public int CreatePlateau(PlateauModel plateau)
        {
            plateauEntity.Add(plateau);

            return plateau.Id;
        }
        
        public PlateauModel ReadPlateau(int plateauId)
        {
            return plateauEntity.FirstOrDefault(x => x.Id == plateauId);
        }

        public bool UpdatePlateau(PlateauModel plateau)
        {
            var index = plateauEntity.FindIndex(x => x.Id == plateau.Id);
            plateauEntity[index] = plateau;

            return true;
        }

        public bool DeletePlateau(int plateauId)
        {
            var roverRecord = ReadPlateau(plateauId);
            plateauEntity.Remove(roverRecord);

            return true;
        }

        public int GetNewPlateauId()
        {
            if (plateauEntity.Any())
            {
                return plateauEntity.LastOrDefault().Id + 1;
            }

            return 1;
        }
    }
}
