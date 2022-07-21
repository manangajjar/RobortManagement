using RobortManagement.Behaviours;
using RobortManagement.BoardTable;
using RobortManagement.ConsoleChecker;
using RobortManagement.Interface.ToyRobot;
using RobortManagement.ToyRobot;
using System;
using Xunit;

namespace ToyRobotTest
{
    public class TestBehaviour
    {
        [Fact]
        public void TestValidBehaviourPlace()
        {
            // arrange
            
            IToyBoardTable squareBoard = new ToyBoardTable(5, 5);
            IInputParser inputParser = new InputParser();
            IRobot robot = new Robot();
            var simulator = new Behaviour(robot, squareBoard, inputParser);

            // act
            simulator.ProcessCommand("PLACE 1,4,EAST".Split(' '));

            // assert
            Assert.Equal(1, robot.Position.X);
            Assert.Equal(4, robot.Position.Y);
            Assert.Equal(Direction.East, robot.Direction);
        }


        [Fact]
        public void TestInvalidBehaviourPlace()
        {
            // arrange
            IToyBoardTable squareBoard = new ToyBoardTable(5, 5);
            IInputParser inputParser = new InputParser();
            IRobot robot = new Robot();
            var simulator = new Behaviour(robot, squareBoard, inputParser);

            // act
            simulator.ProcessCommand("PLACE 9,7,EAST".Split(' '));

            // assert
            Assert.Null(robot.Position);
        }

        /// <summary>
        /// Test a valid move command
        /// </summary>
        [Fact]
        public void TestValidBehaviourMove()
        {
            // arrange
            IToyBoardTable squareBoard = new ToyBoardTable(5, 5);
            IInputParser inputParser = new InputParser();
            IRobot robot = new Robot();
            var simulator = new Behaviour(robot, squareBoard, inputParser);

            // act
            simulator.ProcessCommand("PLACE 3,2,SOUTH".Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));

            // assert
            Assert.Equal("Output: 3,1,SOUTH", simulator.GetReport());
        }

        /// <summary>
        /// Test and invalid move command
        /// </summary>
        [Fact]
        public void TestInvalidBehaviourMove()
        {
            // arrange
            IToyBoardTable squareBoard = new ToyBoardTable(5, 5);
            IInputParser inputParser = new InputParser();
            IRobot robot = new Robot();
            var simulator = new Behaviour(robot, squareBoard, inputParser);

            // act
            simulator.ProcessCommand("PLACE 2,2,NORTH".Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));
            // if the robot goes out of the board it ignores the command
            simulator.ProcessCommand("MOVE".Split(' '));

            // assert
            Assert.Equal("Output: 2,4,NORTH", simulator.GetReport());
        }

        /// <summary>
        /// Test valid movement in the board and test report
        /// </summary>
        [Fact]
        public void TestValidBehaviourReport()
        {
            // arrange
            IToyBoardTable squareBoard = new ToyBoardTable(5, 5);
            IInputParser inputParser = new InputParser();
            IRobot robot = new Robot();
            var simulator = new Behaviour(robot, squareBoard, inputParser);

            // act
            simulator.ProcessCommand("PLACE 3,3,WEST".Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));
            simulator.ProcessCommand("LEFT".Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));
            var output = simulator.ProcessCommand("REPORT".Split(' '));

            // assert
            Assert.Equal("Output: 1,2,SOUTH", output);
        }
    }
}
