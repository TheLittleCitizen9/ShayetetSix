using MenuBuilder;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShayetetSix
{
    public class Validator : BasicValidator
    {
        public Validator(List<string> options):base(options)
        {

        }

        public bool ValidateInt(string input)
        {
            return int.TryParse(input, out _);
        }

        public bool ValidateMissleInput(string input)
        {
            RocketType rocketType;
            return Enum.TryParse(input, true, out rocketType);
        }

        public bool ValidateWar(string input)
        {
            return input == "TotalWar";
        }
    }
}
