using System;
using System.Collections.Generic;
using System.Text;

namespace ShayetetSix
{
    public class Ballistic : IRocket
    {
        private int _successRate;
        private RocketType _type;

        public Ballistic()
        {
            _successRate = 50;
            _type = RocketType.Ballistic;
        }
        public bool IsLaunchSuccessful()
        {
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                int randomValueBetween0And99 = rnd.Next(100);
                if (randomValueBetween0And99 < _successRate)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
