using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureLearn.Data
{
    public class GenerateResult
    {
        float gritScore = 0.0F;

        // Show the user's answer? Then create a Result model class
        public GenerateResult(Dictionary<int, String> selectedOptions)
        {
            foreach (KeyValuePair<int, String> entry in selectedOptions)
            {
                gritScore += new TranslateScore().GetScore(entry.Value);
            }

            // Get average
            gritScore /= selectedOptions.Count;
        }

        public float GetGritScore()
        {
            return gritScore;
        }
    }
}
