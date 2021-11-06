using MissionMars.Data.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissionMars.Data.Core.Model
{
    public class Rover
    {
        public DirectionType DirectionType { get; set; }
        public Coordinates Coordinates { get; set; }
        public MarsSurface MarsSurface { get; set; }
    }
}
