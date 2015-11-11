using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScorer
{
    /// <summary>
    /// Calculates the Bowling total score based on the input score(number of knocked down pins) for each roll
    /// </summary>
    public class Game
    {
        private List<int> rolls = new List<int>(21); // Total 22 integer values to allocate roll scores in a full game

        private int currentRoll = 1; // Indicates current roll at a given point
        
        //Default Constructor
        public Game()
        {
            //Instantiating the integer list(rolls) with all(21) zero values 
            for (int i = 1; i <= 22; i++)
            {
                rolls.Add(0);
            }
        }

        /// <summary>
        /// Roll is called each time the player rolls a ball. 
        /// </summary>
        /// <param name="pins">The argument is the number of pins knocked down.</param>
        public void Roll(int pins)
        {
            //Add the number of knocked down pins to the current roll index
            rolls[currentRoll++] = pins;
        }

        /// <summary>
        /// Score is called only at the very end of the game. 
        /// </summary>
        /// <returns>It returns the total score for that game</returns>
        public int Score()
        {            
            int score = 0;  // Instantiate score with zero to startwith.
            int rollIndex = 1; //Instantiate rollIndex with 1 indicating first roll index in frame 1
            for (int frame = 1; frame <= 10; frame++) // looping through each frame (Total 10 frames) in a game
            {
                if (IsStrike(rollIndex))  // Strike Scenario 
                {
                    score += 10 + StrikeBonus(rollIndex);
                    rollIndex++;  // Incrementing only once to move to next frame, as there will be no next roll in current frame for Strike Scenario
                }
                else if (IsSpare(rollIndex))  // Spare Scenario
                {
                    score += 10 + SpareBonus(rollIndex);
                    rollIndex += 2; // Incrementing twice to move to next frame
                }
                else
                {
                    score += NormalRoll(rollIndex);  // Normal(no strike/spare) Scenario
                    rollIndex += 2; // Incrementing twice to move to next frame
                }
                   
            }
            return score;  // Total Score
        }

        /// <summary>
        /// Normal roll scenario, where two rolls in a frame are counted for score
        /// </summary>
        /// <param name="rollIndex"></param>
        /// <returns>Frame score when no Strike or Spare</returns>
        private int NormalRoll(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1];
        }

        /// <summary>
        /// The bonus for Spare is the number of pins knocked down by the next roll
        /// </summary>
        /// <param name="rollIndex"></param>
        /// <returns>Number of bonus pins</returns>
        private int SpareBonus(int rollIndex)
        {
            return rolls[rollIndex + 2];
        }

        /// <summary>
        /// The bonus for Strike is the value of the next two balls rolled
        /// </summary>
        /// <param name="rollIndex"></param>
        /// <returns>Number of bonus pins</returns>
        private int StrikeBonus(int rollIndex)
        {
            return rolls[rollIndex + 1] + rolls[rollIndex + 2];
        }

        /// <summary>
        /// A spare is when the player knocks down all 10 pins in two tries. The bonus for that frame is the number of
        /// pins knocked down by the next roll.
        /// </summary>
        /// <param name="rollIndex">The argument is roll number for which spare scenario need to be verified.</param>
        /// <returns>Returns True if Spare,otherwise false</returns>
        private bool IsSpare(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1] == 10;
        }

        /// <summary>
        /// A strike is when the player knocks down all 10 pins on his first try. The bonus for that frame is the value of
        ///the next two balls rolled.
        /// </summary>
        /// <param name="rollIndex">The argument is roll number for which strike scenario need to be verified.</param>
        /// <returns>Returns True if Strike,otherwise false</returns>
        private bool IsStrike(int rollIndex)
        {
            return rolls[rollIndex] == 10;
        }
    }
}

    


