using MenuBuilder;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShayetetSix.Actions
{
    public class ExitAction : IActions<Rocket>
    {
        public void Action(params Rocket[] parameters)
        {
            Console.WriteLine("GG warior");
            Environment.Exit(0);
        }
    }
}
