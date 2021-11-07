using MissionMars.Data.Core.Enums;
using MissionMars.Data.Core.Helpers;
using MissionMars.Data.Core.Model;
using MissionMars.Service.Interfaces;
using MissionMars.Service.Services;
using System;
using Xunit;

namespace MissionMars.Test.Unit
{
    public class MarsRoverTest
    {
        [Fact]
        public void RoverTest()
        {

            MarsSurface marsSurface = new MarsSurface(5, 5);

            IRoverActionService roverAction = new RoverActionService();

            var firstRoverCommand = roverAction.MoveCommands(new Rover
            {
                Coordinates = new Coordinates() { X = 1, Y = 2 },
                DirectionType = DirectionType.N,
                MarsSurface = marsSurface,
                MovedCommands = "LMLMLMLMM"
            });

            var secondRoverCommand = roverAction.MoveCommands(new Rover
            {
                Coordinates = new Coordinates() { X = 3, Y = 3 },
                DirectionType = DirectionType.E,
                MarsSurface = marsSurface,
                MovedCommands = "MMRMMRMRRM"
            });


            Assert.NotNull(firstRoverCommand);

            Assert.NotNull(firstRoverCommand);
            Assert.True(firstRoverCommand.Coordinates.X == 1);
            Assert.True(firstRoverCommand.Coordinates.Y == 3);
            Assert.Equal(DirectionType.N, firstRoverCommand.DirectionType);

            Assert.NotNull(secondRoverCommand);

            Assert.NotNull(secondRoverCommand);
            Assert.True(secondRoverCommand.Coordinates.X == 5);
            Assert.True(secondRoverCommand.Coordinates.Y == 1);
            Assert.Equal(DirectionType.E, secondRoverCommand.DirectionType);


        }


        [Fact]
        public void SamePositionRover()
        {
            Rover firstRover = new Rover
            {
                Coordinates = new Coordinates { Y = 1, X = 1 },
                DirectionType = DirectionType.N,
                MarsSurface = new MarsSurface(5, 5)
            };

            Rover secondRover = new Rover
            {
                Coordinates = new Coordinates { Y = 1, X = 1 },
                DirectionType = DirectionType.E,
                MarsSurface = new MarsSurface(5, 5)
            };

            var ex = Assert.Throws<ArgumentException>(() => RoverHelper.CheckRoversPosition(firstRover, secondRover));
            Assert.Equal("Collision warning", ex.Message);

        }


        [Fact]
        public void RoverInMarsSurface()
        {
            Rover firstRover = new Rover
            {
                Coordinates = new Coordinates { Y = 6, X = 4 },
                DirectionType = DirectionType.N,
                MarsSurface = new MarsSurface(5, 5)
            };

            Rover secondRover = new Rover
            {
                Coordinates = new Coordinates { Y = 5, X = 6 },
                DirectionType = DirectionType.E,
                MarsSurface = new MarsSurface(5, 5)
            };

            var exFirstRover = Assert.Throws<ArgumentException>(() => RoverHelper.IsRoverInMarsSurface(firstRover));
            var exSecondRover = Assert.Throws<ArgumentException>(() => RoverHelper.IsRoverInMarsSurface(secondRover));
            Assert.Equal("These coordinates cannot be used as the spacecraft will exit the region.", exFirstRover.Message);
            Assert.Equal("These coordinates cannot be used as the spacecraft will exit the region.", exSecondRover.Message);

        }
    }
}
