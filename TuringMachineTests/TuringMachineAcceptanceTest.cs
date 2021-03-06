﻿using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using TuringMachine.Builders;
using TuringMachine.Domain;

namespace TuringMachineTests
{
    [TestFixture]
    public class TuringMachineAcceptanceTest
    {
        [Test]
        public void CanCreateAndRunTuringMachine()
        {
            var turingMachineBuilder = new TuringMachineBuilder('a', 'b', 'c');

            turingMachineBuilder.SetupTape(new Tape(right: new[] {'a', 'b', 'c'}));
            turingMachineBuilder.ConfigureStateTable()
                .AddTerminalState("q0")
                .AddInitialState("q1")
                .AddTransition(' ', new Transition(' ', MoveType.Right, "q1"))
                .AddTransition('a', new Transition('a', MoveType.Right, "q1"))
                .AddTransition('b', new Transition('b', MoveType.Right, "q1"))
                .AddTransition('c', new Transition('c', MoveType.Right, "q2"));
            turingMachineBuilder.ConfigureStateTable()
                .AddState("q2")
                .AddTransition(' ', new Transition('c', MoveType.Stay, "q0"));
            var turingMachine = turingMachineBuilder.Build();
            var lastSnapshot = turingMachine.ExecuteWithSnapshots().Take(10).Last();
            lastSnapshot.Tape.Should().BeEquivalentTo(new Dictionary<int,char>
            {
                {-4, ' ' },
                {-3, 'a' },
                {-2, 'b' },
                {-1, 'c' },
                {0, 'c' },
            });
        }
    }
}