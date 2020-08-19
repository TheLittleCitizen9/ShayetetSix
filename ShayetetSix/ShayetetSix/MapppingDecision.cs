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

        public IActions<Rocket> MapInput(string input, ConsoleDisplayer consoleDisplayer, ref MisslesLauncher misslesLauncher, ref string[] variables)
        {
            string userInput;
            switch (input)
            {
                case "1":
                    consoleDisplayer.PrintValueToConsole("Enter missle name to add");
                    userInput = Console.ReadLine();
                    variables = userInput.Split(' ');
                    var AddAction = new AddRocketAction(misslesLauncher);
                    misslesLauncher = AddAction.MisslesLauncher;
                    return AddAction;
                case "2":
                    consoleDisplayer.PrintValueToConsole("Enter missle name and number of missles to launch. Use space between the two inputs");
                    userInput = Console.ReadLine();
                    variables = userInput.Split(' ');
                    var launchAction = new LaunchRocketAction(misslesLauncher, int.Parse(variables[1]), variables[0]);
                    misslesLauncher = launchAction.MisslesLauncher;
                    return launchAction;
                case "3":
                    consoleDisplayer.PrintValueToConsole("Printing inventory");
                    return new InventoryReportAction(misslesLauncher);
                case "4":
                    consoleDisplayer.PrintValueToConsole("Enter index to delete from");
                    userInput = Console.ReadLine();
                    variables = userInput.Split(' ');
                    var removeAction = new CleanInventoryAction(misslesLauncher, variables[0]);
                    misslesLauncher = removeAction.MisslesLauncher;
                    return removeAction;
                case "5":
                    consoleDisplayer.PrintValueToConsole("GG warior");
                    return new ExitAction();
                default:
                    return null;
            }
        }

        public Rocket MapRequiresMissleFunctions(string input, params string[] variables)
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

        public Rocket MapTypeToRocket(RocketType rocketType)
        {
            switch (rocketType)
            {
                case RocketType.Torpedo:
                    return new Rocket(100, rocketType);
                case RocketType.Ballistic:
                    return new Rocket(50, rocketType);
                case RocketType.Cruise:
                    return new Rocket(20, rocketType);
                default:
                    return null;
            }
        }
    }
}
