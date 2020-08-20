﻿using MenuBuilder;
using ShayetetSix.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShayetetSix
{
    public class MapppingDecision
    {
        public IActions<Rocket> MapInput(string input, ConsoleDisplayer consoleDisplayer, ref MisslesLauncher misslesLauncher, ref string[] variables)
        {
            string userInput;
            switch (input)
            {
                case "1":
                    consoleDisplayer.PrintValueToConsole("Enter missle name to add");
                    PrintMissleTypes();
                    userInput = Console.ReadLine();
                    variables = userInput.Split(' ');
                    var addAction = new AddRocketAction(misslesLauncher);
                    misslesLauncher = addAction.MisslesLauncher;
                    return addAction;
                case "2":
                    consoleDisplayer.PrintValueToConsole("Enter missle name and number of missles to launch. Use space between the two inputs. Enter 'TotalWar' to launch all missles");
                    userInput = Console.ReadLine();
                    variables = userInput.Split(' ');
                    return CheckLaunchOption(variables, ref misslesLauncher);
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
                    return new ExitAction();
                default:
                    return null;
            }
        }

        public Rocket GetRocketObject(string input, params string[] variables)
        {
            switch (input)
            {
                case "1":
                    var rocketType = (RocketType)Enum.Parse(typeof(RocketType), variables[0], true);
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
                case RocketType.Advanced:
                    Console.WriteLine("Enter range to launch - from 0 to 1500");
                    var range = double.Parse(Console.ReadLine());
                    return new AdvancedRocket(range, RocketType.Advanced);
                default:
                    return null;
            }
        }

        private IActions<Rocket> CheckLaunchOption(string[] variables, ref MisslesLauncher misslesLauncher)
        {
            if (variables.Length == 2)
            {
                var launchAction = new LaunchRocketAction(misslesLauncher, int.Parse(variables[1]), variables[0]);
                misslesLauncher = launchAction.MisslesLauncher;
                return launchAction;
            }
            else
            {
                var launchAction = new LaunchRocketAction(misslesLauncher, 0, variables[0]);
                misslesLauncher = launchAction.MisslesLauncher;
                return launchAction;
            }
        }

        private void PrintMissleTypes()
        {
            foreach (var item in Enum.GetNames(typeof(RocketType)))
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}
