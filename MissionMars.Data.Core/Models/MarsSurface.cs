using System;
using System.Collections.Generic;
using System.Text;

namespace MissionMars.Data.Core.Model
{
    public class MarsSurface
    {
        public MarsSurface(int FirstEdge, int SecondEdge)
        {
            this.EdgeX = FirstEdge;
            this.EdgeY = SecondEdge;
        }

        public int EdgeX { get; set; }
        public int EdgeY { get; set; }
    }
}
