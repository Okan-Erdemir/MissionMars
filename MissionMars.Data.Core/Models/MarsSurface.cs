using System;
using System.Collections.Generic;
using System.Text;

namespace MissionMars.Data.Core.Model
{
    public class MarsSurface
    {
        public MarsSurface(int FirstEdge, int SecondEdge)
        {
            this.FirstEdge = FirstEdge;
            this.SecondEdge = SecondEdge;
        }

        public int FirstEdge { get; set; }
        public int SecondEdge { get; set; }
    }
}
