using RobortManagement.ConsoleChecker;
using RobortManagement.ToyRobot;
using System;
using Xunit;
namespace ToyRobotTest
{
    public class TestConsoleChecker
    {
        /// <summary>
        /// Test valid place command
        /// </summary>
        [Fact]
        public void TestValidPlaceCommand()
        {
            // arrange
            var inputParser = new InputParser();
            string[] rawInput = "PLACE".Split(' ');

            // act
            var command = inputParser.ParseCommand(rawInput);

            // assert
            Assert.Equal(Command.Place, command);
        }

        /// <summary>
        /// Test an invalid place command
        /// </summary>
        [Fact]
        public void TestInvalidPlaceCommand()
        {
            // arrange
            var inputParser = new InputParser();
            string[] rawInput = "PLACETOY".Split(' ');

            // act and assert
            var exception = Assert.Throws<ArgumentException>(delegate { inputParser.ParseCommand(rawInput); });
            Assert.Equal("Sorry, your command was not recognised. Please try again using the following format: PLACE X,Y,F|MOVE|LEFT|RIGHT|REPORT", exception.Message);
        }

        /// <summary>
        /// Test a full place command with valid parameters
        /// </summary>
        [Fact]
        public void TestValidPlaceCommandAndParams()
        {
            // arrange
            var inputParser = new InputParser();
            string[] rawInput = "PLACE 4,3,WEST".Split(' ');

            // act
            var placeCommandParameter = inputParser.ParseCommandParameter(rawInput);

            // assert
            Assert.Equal(4, placeCommandParameter.Position.X);
            Assert.Equal(3, placeCommandParameter.Position.Y);
            Assert.Equal(Direction.West, placeCommandParameter.Direction);
        }

        /// <summary>
        /// Test a place command with an incomplete parameter
        /// </summary>
        [Fact]
        public void TestInvalidPlaceCommandAndParams()
        {
            // arrange
            var inputParser = new InputParser();
            string[] rawInput = "PLACE 3,1".Split(' ');

            // act and assert
            var exception = Assert.Throws<ArgumentException>(delegate
            { var placeCommandParameter = inputParser.ParseCommandParameter(rawInput); });            
            Assert.Equal("Incomplete command. Please ensure that the PLACE command is using format: PLACE X,Y,F", exception.Message);
        }

        /// <summary>
        /// Test a place command with an invalid direction
        /// </summary>
        [Fact]
        public void TestInvalidPlaceDirection()
        {
            // arrange
            var paramParser = new PlaceCommandParameterParser();
            string[] rawInput = "PLACE 2,4,OneDirection".Split(' ');

            // act and assert
            var exception = Assert.Throws<ArgumentException>(delegate { paramParser.ParseParameters(rawInput); });
            Assert.Equal("Invalid direction. Please select from one of the following directions: NORTH|EAST|SOUTH|WEST", exception.Message);         
        }

        /// <summary>
        /// Test a place command with an invalid parameter format
        /// </summary>
        [Fact]
        public void TestInvalidPlaceParamsFormat()
        {
            // arrange
            var paramParser = new PlaceCommandParameterParser();
            string[] rawInput = "PLACE 3,3,SOUTH,2".Split(' ');

            // act and assert
            var exception = Assert.Throws<ArgumentException>(delegate { paramParser.ParseParameters(rawInput); });            
            Assert.Equal("Incomplete command. Please ensure that the PLACE command is using format: PLACE X,Y,F", exception.Message);
        }

    }
}
