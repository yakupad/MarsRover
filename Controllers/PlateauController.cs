using System;
using System.Collections.Generic;
using System.Text;
using MarsRover.Common.Models;
using MarsRover.Core.Service;

namespace MarsRover.Controllers
{
    public class PlateauController
    {
        private readonly IPlateauService _plateauService;

        public PlateauController(IPlateauService plateauService)
        {
            _plateauService = plateauService;
        }

        public int ExploreNewPlateau(int height, int width)
        {
            var newPlateauId = _plateauService.GetNewPlateauId();
            var newPlateau = new PlateauModel
            {
                Id = newPlateauId,
                Height = height,
                Width = width
            };

            return _plateauService.CreatePlateau(newPlateau);
        }
    }
}
