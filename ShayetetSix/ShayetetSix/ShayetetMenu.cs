﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MenuBuilder;

namespace ShayetetSix
{
    public class ShayetetMenu : BasicMenu<Rocket>
    {
        private const string ENTER_VARIABLES = "Enter variables - format X Y";
        private const string ERROR_MSG = "Invalid input";
        private const string ENTER_ROCKET_NAME = "Enter rocket name";
        private readonly List<string> _requaiersInput = new List<string>();

        private Dictionary<string, IActions<Rocket>> _options;

        private Dictionary<string, string> _displayOptions;
        private MisslesLauncher _misslesLauncher = new MisslesLauncher();
        private MapppingDecision _mapppingDecision;


        public ShayetetMenu()
        {
            _options = new Dictionary<string, IActions<Rocket>>();
            _displayOptions = new Dictionary<string, string>();
            _mapppingDecision = new MapppingDecision();
        }

        public override void AddAction(string option, string description, IActions<Rocket> action, bool requiersInput = false)
        {
            if(_options.ContainsKey(option))
            {
                _options[option] = action;
            }
            else
            {
                _options.Add(option, action);
                _displayOptions.Add(option, description);
            }
            
            if (requiersInput)
            {
                _requaiersInput.Add(option);
            }
        }

        public override void Main()
        {
            ConsoleDisplayer consoleDisplayer = new ConsoleDisplayer(_displayOptions);
            Validator validator = new Validator(_options.Keys.ToList());
            string input = string.Empty;
            string[] variables = null;
            while (true)
            {
                consoleDisplayer.ShowOptions();
                input = Console.ReadLine();
                if(validator.Validate(input))
                {
                    if(_requaiersInput.Contains(input))
                    {
                        IActions<Rocket> action = _mapppingDecision.MapInput(input, consoleDisplayer, ref _misslesLauncher, ref variables);
                        AddAction(input, _displayOptions[input], action);
                        Rocket rocket = _mapppingDecision.MapRequiresMissleFunctions(input, variables);
                        if (rocket != null)
                        {
                             _options[input].Action(rocket);
                        }
                        else
                        {
                            _options[input].Action();
                        }
                    }
                    else
                    {
                        IActions<Rocket> action = _mapppingDecision.MapInput(input, consoleDisplayer, ref _misslesLauncher, ref variables);
                        AddAction(input, _displayOptions[input], action);
                        _options[input].Action();
                    }

                }
            }
        }

        

        public override void RunOption(string option, params Rocket[] variables)
        {
            _options[option].Action(variables);
        }
    }
}
