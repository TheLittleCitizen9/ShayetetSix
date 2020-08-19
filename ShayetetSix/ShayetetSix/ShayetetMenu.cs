using System;
using System.Collections.Generic;
using System.Text;
using MenuBuilder;

namespace ShayetetSix
{
    public class ShayetetMenu : BasicMenu<IRocket>
    {
        private const string ENTER_VARIABLES = "Enter variables - format X Y";
        private const string ERROR_MSG = "Invalid input";
        private readonly List<string> _requaiersInput = new List<string>();

        private Dictionary<string, IActions<IRocket>> _options;

        private Dictionary<string, string> _displayOptions;


        public ShayetetMenu()
        {
            _options = new Dictionary<string, IActions<IRocket>>();
            _displayOptions = new Dictionary<string, string>();
        }

        public override void AddAction(string option, string description, IActions<IRocket> action, bool requiersInput = false)
        {
            _options.Add(option, action);
            _displayOptions.Add(option, description);
            if (requiersInput)
            {
                _requaiersInput.Add(option);
            }
        }

        public override void Main()
        {
            throw new NotImplementedException();
        }

        public override void RunOption(string option, params IRocket[] variables)
        {
            _options[option].Action(variables);
        }
    }
}
