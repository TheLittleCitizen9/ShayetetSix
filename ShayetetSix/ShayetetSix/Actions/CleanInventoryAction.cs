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
            int indexOfMissle;
            if(int.TryParse(_indexOfMissleToDelete, out indexOfMissle))
            {
                if(indexOfMissle < MisslesLauncher.MissleLauncher.Count)
                {
                    int index = MisslesLauncher.MissleLauncher.IndexOf(MisslesLauncher.MissleLauncher[indexOfMissle]);
                    MisslesLauncher.MissleLauncher.RemoveAt(indexOfMissle);
                    Console.WriteLine("When the power of love overcomes the love of power the world will know peace");
                }
                else
                {
                    Console.WriteLine("Index is out of range");
                }
            }
        }
    }
}
