using MissionMars.Data.Core.Model;
using System;
using MissionMars.Data.Core.Enums;
using MissionMars.Service.Interfaces;
using MissionMars.Service.Services;
using MissionMars.Data.Core.Helpers;

namespace MissionMars.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("App running");

            Console.WriteLine("input");
            Console.WriteLine("Mars Surface => 5x5", Environment.NewLine);
            Console.WriteLine("First Rover => 1 2 N ", Environment.NewLine);
            Console.WriteLine("Second Rover => 3 3 E ", Environment.NewLine);
            Console.WriteLine("----------------------");
            Console.WriteLine("Output");

            var marsSurface = SetMarsSurface();


            Console.WriteLine("First Rover");
            var firstRoverCommand = SetRover(marsSurface);

            Console.WriteLine("Second Rover");
            var secondRoverCommand = SetRover(marsSurface);

            RoverHelper.CheckRoversPosition(firstRoverCommand, secondRoverCommand);

            Console.WriteLine($"First Rover=> {firstRoverCommand.Coordinates.X} , {firstRoverCommand.Coordinates.Y} , {firstRoverCommand.DirectionType}");
            Console.WriteLine($"Second Rover=> {secondRoverCommand.Coordinates.X} , {secondRoverCommand.Coordinates.Y} , {secondRoverCommand.DirectionType}");


            Console.ReadLine();

        }

        private static MarsSurface SetMarsSurface()
        {
            Console.WriteLine("Enter mars surface X and Y coordinates");
            var edgeX = Convert.ToInt32(Console.ReadLine());
            var edgeY = Convert.ToInt32(Console.ReadLine());

            return new MarsSurface(edgeX, edgeY);
        }

        private static Rover SetRover(MarsSurface marsSurface)
        {
            IRoverActionService roverAction = new RoverActionService();
            Console.WriteLine("Enter Rover X and Y co-ordinates");
            var firstRoverX = Convert.ToInt32(Console.ReadLine());
            var firstRoverY = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Rover Direction Type  (East => E North=> N South => S West => W)");
            var firstRoverDirection = Console.ReadLine();
            Console.WriteLine("Enter Rover Orientation");
            var roverOrientations = Console.ReadLine();

            return roverAction.MoveCommands(new Rover
            {
                Coordinates = new Coordinates() { X = firstRoverX, Y = firstRoverY },
                DirectionType = Enum.Parse<DirectionType>(firstRoverDirection),
                MarsSurface = marsSurface,
                MovedCommands = roverOrientations
            });
        }

    }
}
