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

            MarsSurface marsSurface = new MarsSurface(5, 5);

            IRoverActionService roverAction = new RoverActionService();

            var firstRoverCommand = roverAction.MoveCommands(new Rover
            {
                Coordinates = new Coordinates() { X = 1, Y = 2 },
                DirectionType = DirectionType.N,
                MarsSurface = marsSurface
            }, "LMLMLMLMM");

            var secondRoverCommand = roverAction.MoveCommands(new Rover
            {
                Coordinates = new Coordinates() { X = 3, Y = 3 },
                DirectionType = DirectionType.E,
                MarsSurface = marsSurface
            }, "MMRMMRMRRM");


            RoverHelper.CheckRoversPosition(firstRoverCommand, secondRoverCommand);


            Console.WriteLine($"First Rover=> {firstRoverCommand.Coordinates.X} , {firstRoverCommand.Coordinates.Y} , {firstRoverCommand.DirectionType}");
            Console.WriteLine($"Second Rover=> {secondRoverCommand.Coordinates.X} , {secondRoverCommand.Coordinates.Y} , {secondRoverCommand.DirectionType}");


            Console.ReadLine();

        }
    }
}
