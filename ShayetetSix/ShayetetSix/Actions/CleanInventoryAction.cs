using MenuBuilder;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShayetetSix.Actions
{
    public class CleanInventoryAction : IActions<Rocket>
    {
        public MisslesLauncher MisslesLauncher;
        private string _indexOfMissleToDelete;
        public CleanInventoryAction(MisslesLauncher misslesLauncher, string indexOfMissleToDelete)
        {
            MisslesLauncher = misslesLauncher;
            _indexOfMissleToDelete = indexOfMissleToDelete;
        }
        public void Action(params Rocket[] parameters)
        {
            int numOfMissles;
            if(int.TryParse(_indexOfMissleToDelete, out numOfMissles))
            {
                if(numOfMissles < MisslesLauncher.MissleLauncher.Count)
                {
                    int index = MisslesLauncher.MissleLauncher.IndexOf(MisslesLauncher.MissleLauncher[numOfMissles]);
                    MisslesLauncher.MissleLauncher.RemoveAt(numOfMissles);
                    MisslesLauncher.MisslesFailedLaunchStatus.Remove(index);
                    Console.WriteLine("Missle deleted (:");
                }
                
            }
        }
    }
}
