using RobortManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobortManagement.BoardTable
{
    public interface IToyBoardTable
    {
        // this interface enables access to a boolean method that returns
        // true or false if the position of the robot is within the board table
        bool IsValidPosition(Position position);
    }
}
