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

        // TODO: Supposed to be in database
        public string GetGritMessage()
        {
            if (gritScore > 4.5)
            {
                return "The power of the grit is within you!";
            }
            else if (gritScore > 4.0 && gritScore <= 4.5)
            {
                return "You have a great grit on things!";
            }
            else if (gritScore > 3.5 && gritScore <= 4.0)
            {
                return "You have a good grit on things!";
            }
            else if (gritScore > 3.0 && gritScore <= 3.5)
            {
                return "You have a grit on things!";
            }
            else if (gritScore > 2.0 && gritScore <= 3.0)
            {
                return "The grit is there, but needs a bit more...";
            }
            else
            {
                return "Missing a lot of grittiness!";
            }
        }
    }
}
