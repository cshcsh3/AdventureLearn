using AdventureLearn.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdventureLearn.Services
{
    class RatingService
    {
        // Get rating based on set number
        public static async Task<Rating> GetRating(string set)
        {
            string queryString = "Rating/" + set;

            dynamic results = await DataService.GetDataFromService(queryString).ConfigureAwait(false);

            if (results != null)
            {
                Rating rating = new Rating();

                rating.Set = (string)results["set"];

                JArray rate = (JArray)results["rate"];
                rating.Rate = new string[rate.Count];

                for (int i = 0; i < rate.Count; i++)
                {
                    rating.Rate[i] = (string)rate[i];
                }

                return rating;
            }
            else
            {
                return null;
            }
        }
    }
}
