using System.Threading;

namespace BowlingGame
{
    public class Game
    {
        private readonly int[] rolls = new int[21];
        private int currentRoll;

        public int Score
        {
            get
            {
                var score = 0;
                var frameIndex = 0;
                for (var frame = 0; frame < 10; frame++)
                {
                    if (IsStrike(frameIndex))
                    {
                        score += 10 + StrikeBonus(frameIndex);
                        frameIndex++;
                    }
                    else if (IsSpare(frameIndex))
                    {
                        score += 10 + SpareBonus(frameIndex);
                        frameIndex += 2;
                    }
                    else
                    {
                        score += SumOfBallsInFrame(frameIndex);
                        frameIndex += 2;
                    }
                }
                return score;
            }
        }

        private bool IsStrike(int frameIndex)
        {
            return rolls[frameIndex] == 10;
        }

        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }

        private int StrikeBonus(int frameIndex)
        {
            return rolls[frameIndex + 1] + rolls[frameIndex + 2];
        }

        private int SpareBonus(int frameIndex)
        {
            return rolls[frameIndex + 2];
        }

        private int SumOfBallsInFrame(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1];
        }

        private bool IsSpare(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
        }
    }
}