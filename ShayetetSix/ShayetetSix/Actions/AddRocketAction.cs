using MenuBuilder;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShayetetSix.Actions
{
    public class AddRocketAction : IActions<IRocket>
    {
        public MisslesLauncher MisslesLauncher;
        public AddRocketAction(MisslesLauncher misslesLauncher)
        {
            MisslesLauncher = misslesLauncher;
        }
        public void Action(params IRocket[] parameters)
        {
            if (parameters.Length == 1)
            {
                MisslesLauncher.MissleLauncher.Add(parameters[0]);
                MisslesLauncher.MisslesFailedLaunchStatus[MisslesLauncher.MissleLauncher.Count - 1] = false;
                Console.WriteLine("Rocket added to missile launcher");
            }
        }

        private void AddRocket(params IRocket[] parameters)
        {
            if(parameters.Length == 1)
            {
                MisslesLauncher.MissleLauncher.Add(parameters[0]);
                MisslesLauncher.MisslesFailedLaunchStatus[MisslesLauncher.MissleLauncher.Count - 1] = false;
            }
        }
    }
}
