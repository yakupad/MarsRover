using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRover.Common.Models;
using MarsRover.Core.Repository;

namespace MarsRover.Repository
{
    public class PlateauRepository : BaseRepository, IPlateauRepository
    {
        List<PlateauModel> plateauEntity = new List<PlateauModel>();

        public bool CreatePlateau(PlateauModel plateau)
        {
            var newPlateau = new PlateauModel
            {
                Id = plateau.Id,
                Height = plateau.Height,
                Width = plateau.Width
            };

            plateauEntity.Add(newPlateau);

            return true;
        }

        public PlateauModel GetPlateau(int plateauId)
        {
            var plateauRecord = plateauEntity.FirstOrDefault(x => x.Id == plateauId);

            return plateauRecord;
        }

        public bool UpdatePlateau(PlateauModel plateau)
        {
            // @todo buraya update fonksiyonu yazılacak
            return true;
        }

        public bool RemovePlateau(int plateauId)
        {
            plateauEntity.Remove(GetPlateau(plateauId));

            return true;
        }
    }
}
