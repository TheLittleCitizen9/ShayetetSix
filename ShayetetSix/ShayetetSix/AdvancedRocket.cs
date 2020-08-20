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

        public override bool IsLaunchSuccessful()
        {
            double percentageOfSuccess = (FULL_RANGE - SuccessRate)/1500 * 100;
            if(percentageOfSuccess == 100)
            {
                return true;
            }
            else if(percentageOfSuccess == 0)
            {
                return false;
            }
            else
            {
                SuccessRate = percentageOfSuccess;
                return base.IsLaunchSuccessful();
            }
        }
    }
}
