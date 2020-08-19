using MenuBuilder;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShayetetSix.Actions
{
    public class LaunchRocketAction : IActions<Rocket>
    {
        public MisslesLauncher MisslesLauncher;
        private int _numOfMisslesToLaunch;
        private string _nameOfMissleToLaunch;
        public LaunchRocketAction(MisslesLauncher misslesLauncher, int numOfMisslesToLaunch, string nameOfMissle)
        {
            MisslesLauncher = misslesLauncher;
            _numOfMisslesToLaunch = numOfMisslesToLaunch;
            _nameOfMissleToLaunch = nameOfMissle;
        }
        public void Action(params Rocket[] parameters)
        {
            Validator validator = new Validator(null);
            if (validator.ValidateMissleInput(_nameOfMissleToLaunch))
            {
                LaunchSpecificMissles();
            }
            else if(_nameOfMissleToLaunch == "TotalWar")
            {
                LaunchAllMissles();
            }
        }

        private void LaunchAllMissles()
        {
            int countOfLaunches = 0;
            for (int i = 0; i < MisslesLauncher.MissleLauncher.Count; i++)
            {
                if(!MisslesLauncher.MisslesFailedLaunchStatus[i])
                {
                    bool isLaunchSuccessful = MisslesLauncher.MissleLauncher[i].IsLaunchSuccessful();
                    if (!isLaunchSuccessful)
                    {
                        MisslesLauncher.MisslesFailedLaunchStatus[i] = true;
                    }
                    else
                    {
                        countOfLaunches++;
                    }
                }
                
            }
            Console.WriteLine($"{countOfLaunches} missles where launched successfully");
        }

        private void LaunchSpecificMissles()
        {
            int countOfLaunches = 0;
            for (int i = 0; i < MisslesLauncher.MissleLauncher.Count; i++)
            {
                if (MisslesLauncher.MissleLauncher[i].Type == (RocketType)Enum.Parse(typeof(RocketType), _nameOfMissleToLaunch, true) && countOfLaunches < _numOfMisslesToLaunch)
                {
                    if(!MisslesLauncher.MisslesFailedLaunchStatus[i])
                    {
                        bool isLaunchSuccessful = MisslesLauncher.MissleLauncher[i].IsLaunchSuccessful();
                        if (!isLaunchSuccessful)
                        {
                            MisslesLauncher.MisslesFailedLaunchStatus[i] = true;
                        }
                        else
                        {
                            IActions<Rocket> remove = new CleanInventoryAction(MisslesLauncher, $"{i}");
                            remove.Action();
                            countOfLaunches++;
                        }
                    }
                }

            }
            Console.WriteLine($"{countOfLaunches} missles where launched successfully");
        }

    }
}
