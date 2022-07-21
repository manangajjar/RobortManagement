using RobortManagement;
using RobortManagement.ConsoleChecker;
using RobortManagement.ToyRobot;
using System;
using Xunit;

namespace ToyRobotTest
{
    public class TestToyRobot
    {
        /// <summary>
        /// Test toy turn left
        /// </summary>
        [Fact]
        public void TestValidToyTurnLeft()
        {
            // arrange
            var robot = new Robot { Direction = Direction.West, Position = new Position(2, 2) };

            // act
            robot.RotateLeft();

            // assert
            Assert.Equal(Direction.South, robot.Direction);
        }

        /// <summary>
        /// Test toy turn right
        /// </summary>
        [Fact]
        public void TestValidToyTurnRight()
        {
            // arrange
            var robot = new Robot { Direction = Direction.West, Position = new Position(2, 2) };

            // act
            robot.RotateRight();

            // assert
            Assert.Equal(Direction.North, robot.Direction);
        }


        /// <summary>
        /// Test move
        /// </summary>
        [Fact]
        public void TestValidToyMove()
        {
            // arrange
            var robot = new Robot { Direction = Direction.East, Position = new Position(2, 2) };

            // act
            var nextPosition = robot.GetNextPosition();

            // assert
            Assert.Equal(3, nextPosition.X);
            Assert.Equal(2, nextPosition.Y);
        }

        /// <summary>
        /// Test set toy position and direction
        /// </summary>
        [Fact]
        public void TestValidToyPositionAndDirection()
        {
            // arrange
            var position = new Position(3, 3);
            var robot = new Robot();

            // act
            robot.Place(position, Direction.North);

            // assert
            Assert.Equal(3, robot.Position.X);
            Assert.Equal(3, robot.Position.Y);
            Assert.Equal(Direction.North, robot.Direction);
        }
    }
}
