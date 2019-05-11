﻿using System.Collections.Generic;
using System.Linq;
using TuringMachine.Builders;
using TuringMachine.Domain;
using TuringMachine.Web.Models;

namespace TuringMachine.Web.Common
{
    public static class TuringMachineRunner
    {
        private const string terminalState = "stop";

        public static List<ExecutingSnapshot> Run(TuringMachineModel model)
        {
            return Build(model).ExecuteWithSnapshots().Take(500).ToList();
        }

        private static Domain.TuringMachine Build(TuringMachineModel model)
        {
            var builder = new TuringMachineBuilder(model.Alphabet);
            builder.SetupTape(TapeParser.Parse(model.Tape));
            var configureStateTable = builder.ConfigureStateTable();
            configureStateTable.AddTerminalState(terminalState);

            var first = true;
            var stateIndex = 0;
            foreach (var state in model.Transitions.Batch(model.Alphabet.Length))
            {
                var stateBuilder = first
                    ? configureStateTable.AddInitialState(model.States[stateIndex])
                    : configureStateTable.AddState(model.States[stateIndex]);

                var wordIndex = 0;
                foreach (var transitionItem in state)
                {
                    var transition = TransitionParser.Parse(transitionItem);
                    if (transition != null)
                        stateBuilder.AddTransition(model.Alphabet[wordIndex], transition);
                    wordIndex++;
                }

                stateIndex++;
                first = false;
            }

            return builder.Build();
        }
    }
}