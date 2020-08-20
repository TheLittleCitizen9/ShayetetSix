using System;
using System.Collections.Generic;
using System.Text;

namespace ShayetetSix
{
    public class Rocket : IRocket, ILaunchTechnique
    {
        public double SuccessRate;
        public RocketType Type;

        public Rocket(double successRate, RocketType rocketType)
        {
            SuccessRate = successRate;
            Type = rocketType;
        }

        public virtual bool IsLaunchSuccessful()
        {
            Random rnd = new Random();
            int randomValueBetween0And99 = rnd.Next(100);
            if (randomValueBetween0And99 < SuccessRate)
            {
                return true;
            }
            return false;
        }
    }
}
