using MenuBuilder;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShayetetSix.Actions
{
    public class InventoryReportAction : IActions<Rocket>
    {
        public MisslesLauncher MisslesLauncher;
        public InventoryReportAction(MisslesLauncher misslesLauncher)
        {
            MisslesLauncher = misslesLauncher;
        }
        public void Action(params Rocket[] parameters)
        {
            Console.WriteLine($"The number of missles in stock are: {MisslesLauncher.MissleLauncher.Count}");
            foreach (var missle in MisslesLauncher.MissleLauncher)
            {
                Console.WriteLine($"- {missle.Type}");
            }
        }
    }
}
