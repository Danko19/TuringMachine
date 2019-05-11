using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using TuringMachine.Domain;

namespace TuringMachineTests
{
    [TestFixture]
    public class TapeTests
    {
        [Test]
        public void EmptyTape_CanBeCreated()
        {
            var tape = new Tape();
            tape.ToArray().Should().BeEquivalentTo(' ');
        }

        [Test]
        [TestCase(null, null)]
        [TestCase(null, "abc")]
        [TestCase("abc", null)]
        [TestCase("abc", "abc")]
        public void FilledTape_CanBeCreated(string left, string right)
        {
            var tape = new Tape(left, '_', right);

            tape.Current.Should().Be('_');
            tape.GetLeft().ToArray().Should().BeEquivalentTo($"{left}");
            tape.GetRight().ToArray().Should().BeEquivalentTo($"{right}");
            tape.ToArray().Should().BeEquivalentTo($"{left}_{right}");
        }

        [Test]
        [TestCase("→", 'M')]
        [TestCase("←", 'g')]
        [TestCase("→ → →", 'c')]
        [TestCase("← ← ← ←", 'r')]
        [TestCase("← ← → ← ←", 'i')]
        [TestCase("← ← ← ← → → → → → →", 'a')]
        [TestCase("← ← ← ← ← ← ← ← ← ← ← ←", ' ')]
        [TestCase("→ → → → → → → → → → → →", ' ')]
        public void Tape_CanMovePoint(string moves, char expectedCurrent)
        {
            var tape = new Tape("Turing", '_', "Machine");

            foreach (var move in moves)
            {
                if (move == '→')
                    tape.MoveRight();
                if (move == '←')
                    tape.MoveLeft();
            }

            tape.Current.Should().Be(expectedCurrent);
        }

        [Test]
        public void Tape_CanSetValues()
        {
            var tape = new Tape();

            tape.Current = 'b';
            tape.MoveRight();
            tape.Current = 'c';
            tape.MoveLeft();
            tape.MoveLeft();
            tape.Current = 'a';

            tape.ToArray().Should().BeEquivalentTo("abc");
        }
    }
}