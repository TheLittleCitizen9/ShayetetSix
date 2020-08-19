using MenuBuilder;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShayetetSix.Actions
{
    public class CleanInventoryAction : IActions<IRocket>
    {
        public MisslesLauncher MisslesLauncher;
        private int _numOfMisslesToLaunch;
        public CleanInventoryAction(MisslesLauncher misslesLauncher, int numOfMisslesToLaunch)
        {
            MisslesLauncher = misslesLauncher;
            _numOfMisslesToLaunch = numOfMisslesToLaunch;
        }
        public void Action(params IRocket[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}
