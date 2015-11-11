using System;
using BowlingScorer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestBowlingScorer
{
    [TestClass]
    public class BowlingScorerTests
    {     
        [TestMethod]
        public void TestRollsAsInRequirementWithInvalidTenthRollScenario()
        {
            var game = new Game();
            RollPinsAsPerRequirement(game);
            game.Roll(6); //Invalid 4th roll in 10th frame
            Assert.AreEqual(133, game.Score());
        }

        [TestMethod]
        public void TestRollsAsInRequirementScenario()
        {
            var game = new Game();
            RollPinsAsPerRequirement(game);
            Assert.AreEqual(133, game.Score());
        }

        [TestMethod]
        public void TestNoPinsHitScenario()
        {
            var game = new Game();
            RollPins(game, 20, 0);
            Assert.AreEqual(0, game.Score());
        }

        [TestMethod]
        public void TestASpareScenario()
        {
            var game = new Game();
            RolledASpare(game);
            game.Roll(6);
            RollPins(game, 17, 0);
            Assert.AreEqual(22, game.Score());
        }


        [TestMethod]
        public void TestAStrikeScenario()
        {
            var game = new Game();
            RolledAStrike(game);
            game.Roll(4);
            game.Roll(4);
            RollPins(game, 16, 0);
            Assert.AreEqual(26, game.Score());
        }

        [TestMethod]
        public void TestFullScoreScenario()
        {
            var game = new Game();
            RollPins(game, 12, 10);
            Assert.AreEqual(300, game.Score());
        }

       
        
        private void RollPinsAsPerRequirement(Game game)
        {
            game.Roll(1);
            game.Roll(4);

            game.Roll(4);
            game.Roll(5);

            game.Roll(6);
            game.Roll(4);

            game.Roll(5);
            game.Roll(5);

            game.Roll(10);

            game.Roll(0);
            game.Roll(1);

            game.Roll(7);
            game.Roll(3);

            game.Roll(6);
            game.Roll(4);

            game.Roll(10);

            game.Roll(2);
            game.Roll(8);
            game.Roll(6);
        }

        private void RollPins(Game game, int numberOfRolls, int pinsScored)
        {
            for (int i = 0; i < numberOfRolls; i++)
            {
                game.Roll(pinsScored);
            }
        }

        private void RolledASpare(Game game)
        {
            game.Roll(8);
            game.Roll(2);
        }

        private void RolledAStrike(Game game)
        {
            game.Roll(10);
        }
    }
}
