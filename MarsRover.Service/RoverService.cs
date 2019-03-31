using System.Collections.Generic;
using System.Linq;
using MarsRover.Common.Models;
using MarsRover.Core.Service;

namespace MarsRover.Service
{
    public class RoverService : BaseService, IRoverService
    {
        List<RoverModel> roverEntity = new List<RoverModel>();

        public int CreateRover(RoverModel rover)
        {
            roverEntity.Add(rover);

            return rover.Id;
        }

        public RoverModel ReadRover(int roverId)
        {
            return roverEntity.FirstOrDefault(x => x.Id == roverId);
        }

        public bool DeleteRover(int roverId)
        {
            var roverRecord = ReadRover(roverId);
            roverEntity.Remove(roverRecord);

            return true;
        }
        
        public bool UpdateRover(RoverModel rover)
        {
            var index = roverEntity.FindIndex(x => x.Id == rover.Id);
            roverEntity[index] = rover;

            return true;
        }

        public int GetNewRoverId()
        {
            if (roverEntity.Any())
            {
                return roverEntity.LastOrDefault().Id + 1;
            }

            return 1;
        }
    }
}
