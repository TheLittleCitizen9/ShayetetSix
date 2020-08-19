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
            Environment.Exit(0);
        }
    }
}
