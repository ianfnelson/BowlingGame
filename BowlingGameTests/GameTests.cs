using BowlingGame;
using FluentAssertions;
using NUnit.Framework;

namespace BowlingGameTests
{
    [TestFixture]
    public class GameTests
    {
        [SetUp]
        public void SetUp()
        {
            game = new Game();
        }

        private Game game;

        private void RollMany(int n, int pins)
        {
            for (var ball = 0; ball < n; ball++)
            {
                game.Roll(pins);
            }
        }

        private void RollSpare()
        {
            game.Roll(5);
            game.Roll(5); // Spare
        }

        private void RollStrike()
        {
            game.Roll(10);
        }

        [Test]
        public void TestAllOnes()
        {
            RollMany(20, 1);
            game.Score.Should().Be(20);
        }

        [Test]
        public void TestGutterGame()
        {
            RollMany(20, 0);
            game.Score.Should().Be(0);
        }

        [Test]
        public void TestOneSpare()
        {
            RollSpare();
            game.Roll(3);

            RollMany(17, 0);

            game.Score.Should().Be(16);
        }

        [Test]
        public void TestOneStrike()
        {
            RollStrike();
            game.Roll(3);
            game.Roll(4);
            RollMany(16, 0);

            game.Score.Should().Be(24);
        }

        [Test]
        public void TestPerfectGame()
        {
            RollMany(12,10);
            game.Score.Should().Be(300);
        }
    }
}