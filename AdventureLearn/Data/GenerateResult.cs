using AdventureLearn.Models;
using AdventureLearn.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdventureLearn.Data
{
    public class GenerateResult
    {
        string set;
        Dictionary<int, String> selectedOptions;

        // Show the user's answer? Then create a Result model class
        public GenerateResult(Dictionary<int, String> selectedOptions, string set)
        {
            this.set = set;
            this.selectedOptions = selectedOptions;
        }

        private async Task<float> TranslateScore(string option, string set) {
            Rating rating = await RatingService.GetRating(set);

            for (int i = 0; i < rating.Rate.Length; i++)
            {
                if (rating.Rate[i].Equals(option))
                {
                    return i+1;
                }
            }
            return 0;
        }

        public async Task<float> GetScore()
        {
            float score = 0.0F;

            foreach (KeyValuePair<int, String> entry in selectedOptions)
            {
                score += await TranslateScore(entry.Value, set);
            }



            // Get average
            score /= selectedOptions.Count;
            return score;
        }

        // TODO: In database
        public string GetMessage(float score)
        {   
            if (score > 4.5)
            {
                return "You're doing fantastic.";
            }
            else if (score > 4.0 && score <= 4.5)
            {
                return "You're doing great.";
            }
            else if (score > 3.5 && score <= 4.0)
            {
                return "You're doing good.";
            }
            else if (score > 3.0 && score <= 3.5)
            {
                return "Not bad.";
            }
            else if (score > 2.0 && score <= 3.0)
            {
                return "You are doing alright.";
            }
            else
            {
                return "You need to bulk up.";
            }
        }
    }
}
