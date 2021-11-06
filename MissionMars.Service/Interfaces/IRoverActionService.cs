using MissionMars.Data.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissionMars.Service.Interfaces
{
    public interface IRoverActionService
    {
        Rover MoveCommands(Rover rover, string movedCommands);
    }
}
