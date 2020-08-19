using System;
using System.Collections.Generic;
using System.Text;

namespace ShayetetSix
{
    public class MisslesLauncher
    {
        public Dictionary<int, bool> MisslesFailedLaunchStatus = new Dictionary<int, bool>();
        public List<Rocket> MissleLauncher = new List<Rocket>();

        public MisslesLauncher()
        {

        }
    }
}
