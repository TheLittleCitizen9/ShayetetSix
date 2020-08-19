using MenuBuilder;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShayetetSix.Actions
{
    public class LaunchRocketAction : IActions<IRocket>
    {
        public MisslesLauncher MisslesLauncher;
        public LaunchRocketAction(MisslesLauncher misslesLauncher)
        {
            MisslesLauncher = misslesLauncher;
        }
        public void Action(params IRocket[] parameters)
        {
            
        }

    }
}
