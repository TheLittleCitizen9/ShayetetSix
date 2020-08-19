using MenuBuilder;
using ShayetetSix.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShayetetSix
{
    public class MapppingDecision
    {
        //public object MapInput(string input, Validator validator, ConsoleDisplayer consoleDisplayer)
        //{
        //    switch (input)
        //    {
        //        case "1":
        //            if (validator.ValidateMissleInput(input))
        //            {
        //                var rocketType = (RocketType)Enum.Parse(typeof(RocketType), input, true);
        //                return MapTypeToRocket(rocketType);
        //            }
        //            return null;
        //        case "2":
        //            consoleDisplayer.PrintValueToConsole("Enter missle name and number of missles to launch. Use space between the two inputs");
        //            string[] variables = Console.ReadLine().Split(' ');
        //            if(validator.ValidateMissleInput(input))
        //            {
        //                return (variables[0], variables[1]);
        //            }
        //            return null;
        //        case "3":
        //            break;
        //        case "4":
        //            break;
        //        case "5":
        //            break;
        //        default:
        //            break;
        //    }
        //}

        public IActions<IRocket> MapInput(string input, ConsoleDisplayer consoleDisplayer, MisslesLauncher misslesLauncher, params string[] variables)
        {
            switch (input)
            {
                case "1":
                    consoleDisplayer.PrintValueToConsole("Enter missle name to add");
                    return new AddRocketAction(misslesLauncher);
                case "2":
                    consoleDisplayer.PrintValueToConsole("Enter missle name and number of missles to launch. Use space between the two inputs");
                    return new LaunchRocketAction(misslesLauncher);
                case "3":
                    consoleDisplayer.PrintValueToConsole("Printing inventory");
                    return "3";
                case "4":
                    consoleDisplayer.PrintValueToConsole("Enter index to delete from");
                    return new CleanInventoryAction(misslesLauncher, int.Parse(variables[1]));
                case "5":
                    consoleDisplayer.PrintValueToConsole("GG warior");
                    return "5";
                default:
                    return "-1";
            }
        }

        public IRocket MapRequiresMissleFunctions(string input, params string[] variables)
        {
            switch (input)
            {
                case "1":
                    var rocketType = (RocketType)Enum.Parse(typeof(RocketType), variables[0], true);
                    return MapTypeToRocket(rocketType);
                case "2":
                    rocketType = (RocketType)Enum.Parse(typeof(RocketType), variables[0], true);
                    return MapTypeToRocket(rocketType);
                default:
                    return null;
            }
        }

        public IRocket MapTypeToRocket(RocketType rocketType)
        {
            switch (rocketType)
            {
                case RocketType.Torpedo:
                    return new Torpedo();
                case RocketType.Ballistic:
                    return new Ballistic();
                case RocketType.Cruise:
                    return new Cruise();
                default:
                    return null;
            }
        }
    }
}
