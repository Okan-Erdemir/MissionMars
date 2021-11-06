using MissionMars.Data.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissionMars.Data.Core.Helpers
{
    public static class RoverHelper
    {
        public static void IsRoverInMarsSurface(Rover rover)
        {
            if (rover.Coordinates.X > rover.MarsSurface.FirstEdge || rover.Coordinates.Y > rover.MarsSurface.SecondEdge)
            {
                throw new ArgumentException("These coordinates cannot be used as the spacecraft will exit the region.");
            }
        }

        public static void CheckRoversPosition(Rover firstRover, Rover secondRover)
        {
            if ((firstRover.Coordinates.X == secondRover.Coordinates.X) && (firstRover.Coordinates.Y == secondRover.Coordinates.Y))
            {
                throw new ArgumentException("Collision warning");
            }
        }

    }
}
