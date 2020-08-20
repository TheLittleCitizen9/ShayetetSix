using MenuBuilder;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShayetetSix.Actions
{
    public class AddRocketAction : IActions<Rocket>
    {
        public MisslesLauncher MisslesLauncher;
        public AddRocketAction(MisslesLauncher misslesLauncher)
        {
            MisslesLauncher = misslesLauncher;
        }
        public void Action(params Rocket[] parameters)
        {
            if (parameters.Length == 1)
            {
                MisslesLauncher.MissleLauncher.Add(parameters[0]);
                Console.WriteLine("Rocket added to missile launcher");
            }
        }
    }
}
