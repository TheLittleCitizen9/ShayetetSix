using System;
using System.Collections.Generic;
using System.Text;

namespace ShayetetSix
{
    public class Torpedo : IRocket
    {
        private int _successRate;
        private RocketType _type;

        public Torpedo()
        {
            _successRate = 100;
            _type = RocketType.Torpedo;
        }

        public bool IsLaunchSuccessful()
        {
            return true;
        }
    }
}
