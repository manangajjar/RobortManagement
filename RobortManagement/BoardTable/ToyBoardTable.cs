using RobortManagement.ToyRobot;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobortManagement.BoardTable
{
    public class ToyBoardTable : IToyBoardTable
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public ToyBoardTable(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
        }

        // Check whether the position specified is inside the boundaries of the square board.
        public bool IsValidPosition(Position position)
        {
            return position.X < Columns && position.X >= 0 &&
                   position.Y < Rows && position.Y >= 0;
        }
    }
}
