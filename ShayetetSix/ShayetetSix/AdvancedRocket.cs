using System;
using System.Collections.Generic;
using System.Text;

namespace ShayetetSix
{
    public class AdvancedRocket : Rocket
    {
        private const int FULL_RANGE = 1500;
        public AdvancedRocket(double successRate, RocketType rocketType):base(successRate, rocketType)
        {

        }

        public override void IsLaunchSuccessful()
        {
            double percentageOfSuccess = FULL_RANGE - SuccessRate;
            if(percentageOfSuccess == 1500)
            {
                LaunchFailedStatus = true;
            }
            else
            {
                SuccessRate = percentageOfSuccess;
                base.IsLaunchSuccessful();
            }
        }
    }
}
