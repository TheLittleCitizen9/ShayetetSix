using MenuBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShayetetSix.Actions
{
    public class LaunchRocketAction : IActions<Rocket>
    {
        public MisslesLauncher MisslesLauncher;
        private int _numOfMisslesToLaunch;
        private string _nameOfMissleToLaunch;
        private List<Rocket> _duplicateList;
        public LaunchRocketAction(MisslesLauncher misslesLauncher, int numOfMisslesToLaunch, string nameOfMissle)
        {
            MisslesLauncher = misslesLauncher;
            _numOfMisslesToLaunch = numOfMisslesToLaunch;
            _nameOfMissleToLaunch = nameOfMissle;
            _duplicateList = MisslesLauncher.MissleLauncher.Select(m => m).ToList();
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
            List<Rocket> duplicateList = MisslesLauncher.MissleLauncher.Select(m => m).ToList();
            int countOfLaunches = 0;
            for (int i = 0; i < duplicateList.Count; i++)
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
            DeleteAllRockets();
            Console.WriteLine($"{countOfLaunches} missles where launched successfully");
        }

        private void LaunchSpecificMissles()
        {
            int countOfLaunches = 0;
            for (int i = 0; i < _duplicateList.Count; i++)
            {
                if (_duplicateList[i].Type == (RocketType)Enum.Parse(typeof(RocketType), _nameOfMissleToLaunch, true) && countOfLaunches < _numOfMisslesToLaunch)
                {
                    if(!MisslesLauncher.MisslesFailedLaunchStatus[i])
                    {
                        bool isLaunchSuccessful = _duplicateList[i].IsLaunchSuccessful();
                        if (!isLaunchSuccessful)
                        {
                            MisslesLauncher.MisslesFailedLaunchStatus[i] = true;
                        }
                        else
                        {
                            DeleteRocket(1);
                            countOfLaunches++;
                        }
                    }
                }

            }
            Console.WriteLine($"{countOfLaunches} missles where launched successfully");
        }

        private void DeleteRocket(int numOfRocketsToDelete)
        {
            int countOfDelete = 0;
            for (int i = 0; i < MisslesLauncher.MissleLauncher.Count; i++)
            {
                if(MisslesLauncher.MissleLauncher[i].Type == (RocketType)Enum.Parse(typeof(RocketType), _nameOfMissleToLaunch, true) && countOfDelete < numOfRocketsToDelete)
                {
                    MisslesLauncher.MissleLauncher.RemoveAt(i);
                    MisslesLauncher.MisslesFailedLaunchStatus.Remove(i);
                    countOfDelete++;
                }
            }
        }

        private void DeleteAllRockets()
        {
            for (int i = 0; i < _duplicateList.Count; i++)
            {
                if(!MisslesLauncher.MisslesFailedLaunchStatus[i])
                {
                    MisslesLauncher.MissleLauncher.RemoveAt(i);
                }
            }
        }

    }
}
