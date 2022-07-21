using RobortManagement.ToyRobot;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobortManagement.ConsoleChecker
{
    // This is a class to store the parameters for the "PLACE" command.
    public class PlaceCommandParameter
    {
        public Position Position { get; set; }
        public Direction Direction { get; set; }

        public PlaceCommandParameter(Position position, Direction direction)
        {
            Position = position;
            Direction = direction;
        }
    }
}
