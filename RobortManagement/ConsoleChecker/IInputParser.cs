using RobortManagement.ToyRobot;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobortManagement.ConsoleChecker
{
    public interface IInputParser
    {
        // Interface to process the raw input from the user.
        Command ParseCommand(string[] rawInput);

        // This extracts the parameters from the user's input.        
        PlaceCommandParameter ParseCommandParameter(string[] input);
    }
}
