using RobortManagement;
using RobortManagement.BoardTable;
using Xunit;

namespace ToyRobotTest
{
    public class TestBoard
    {
        /// <summary>
        /// Try to put the toy outside of the board
        /// </summary>
        [Fact]
        public void TestInvalidBoardPosition()
        {
            // arrange
            IToyBoardTable squareBoard = new ToyBoardTable(5, 5);
            Position position = new Position(6, 6);

            // act
            var result = squareBoard.IsValidPosition(position);

            // assert
            Assert.False(result);
        }

        /// <summary>
        /// Test valid positon 
        /// </summary>
        [Fact]
        public void TestValidBoardPosition()
        {
            // arrange
            IToyBoardTable squareBoard = new ToyBoardTable(5, 5);
            Position position = new Position(1, 4);

            // act
            var result = squareBoard.IsValidPosition(position);

            // assert
            Assert.True(result);
        }
    }
}
