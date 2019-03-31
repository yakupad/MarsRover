using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using Microsoft.Extensions.DependencyInjection;
using MarsRover.Common.Enums;
using MarsRover.Common.Models;
using MarsRover.Controllers;
using MarsRover.Core.Service;
using MarsRover.Service;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<IPlateauService, PlateauService>()
                .AddScoped<IRoverService, RoverService>()
                .AddScoped<INavigationService, NavigationService>()
                .BuildServiceProvider();

            PlateauController plateau = new PlateauController(
                serviceProvider.GetService<IPlateauService>());
            RoverController rover = new RoverController(
                serviceProvider.GetService<IRoverService>(),
                serviceProvider.GetService<INavigationService>(),
                serviceProvider.GetService<IPlateauService>());
            

            var plateauId = plateau.ExploreNewPlateau(5, 5);

            var newRoverId = rover.AddRover(1, 2, CompassPoint.North, plateauId);
            rover.Navigate(newRoverId, Move.TurnLeft);
            rover.Navigate(newRoverId, Move.Forward);
            rover.Navigate(newRoverId, Move.TurnLeft);
            rover.Navigate(newRoverId, Move.Forward);
            rover.Navigate(newRoverId, Move.TurnLeft);
            rover.Navigate(newRoverId, Move.Forward);
            rover.Navigate(newRoverId, Move.TurnLeft);
            rover.Navigate(newRoverId, Move.Forward);
            rover.Navigate(newRoverId, Move.Forward);
            
            var newRover2Id = rover.AddRover(3, 3, CompassPoint.East, plateauId);
            rover.Navigate(newRover2Id, Move.Forward);
            rover.Navigate(newRover2Id, Move.Forward);
            rover.Navigate(newRover2Id, Move.TurnRight);
            rover.Navigate(newRover2Id, Move.Forward);
            rover.Navigate(newRover2Id, Move.Forward);
            rover.Navigate(newRover2Id, Move.TurnRight);
            rover.Navigate(newRover2Id, Move.Forward);
            rover.Navigate(newRover2Id, Move.TurnRight);
            rover.Navigate(newRover2Id, Move.TurnRight);
            rover.Navigate(newRover2Id, Move.Forward);

            Console.WriteLine(rover.GetRoverCurrentLocationMessage(newRoverId));
            Console.WriteLine(rover.GetRoverCurrentLocationMessage(newRover2Id));
            Console.ReadKey();

            //Console.WriteLine("Welcome to NASA Rover Project! ProjectId: 34354527 \n");
            //Console.WriteLine("Please enter plateau coordinates: e.g: 5 5");
            //var plateauCoordianates = Console.ReadLine().Split(" ");
            //Console.WriteLine("Please enter rover 1 coordinates: e.g: 1 2 N");
            //var rover1Coordianates = Console.ReadLine().Split(" ");
            //Console.WriteLine("Please enter navigation commands: e.g: LMLMLMLMM");
            //var rover1NavigationCommands = Console.ReadLine().Split();
            //Console.WriteLine("Please enter rover 2 coordinates: e.g: 1 2 N");
            //var roverCoordianates = Console.ReadLine().Split(" ");
            //Console.WriteLine("Please enter navigation commands: e.g: LMLMLMLMM");
            //var rover2NavigationCommands = Console.ReadLine().Split();
        }
    }
}
