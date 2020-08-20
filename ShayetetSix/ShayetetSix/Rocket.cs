using System;
using System.Collections.Generic;
using System.Text;

namespace ShayetetSix
{
    public class Rocket : IRocket
    {
        public double SuccessRate;
        public RocketType Type;
        public bool LaunchFailedStatus;

        public Rocket(double successRate, RocketType rocketType)
        {
            SuccessRate = successRate;
            Type = rocketType;
            LaunchFailedStatus = false;
        }

        public virtual bool IsLaunchSuccessful()
        {
            Random rnd = new Random();
            int randomValueBetween0And99 = rnd.Next(100);
            if (randomValueBetween0And99 < SuccessRate)
            {
                return true;
            }

            LaunchFailedStatus = true;
            return false;
        }
    }
}
