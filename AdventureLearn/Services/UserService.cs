using AdventureLearn.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp;
using Newtonsoft.Json.Linq;

namespace AdventureLearn.Services
{
    public class UserService
    {
        public static async Task<User> GetUser(string email)
        {
            // TODO: Implement API key and password authentication
            string queryString = "User/" + email;

            dynamic results = await DataService.GetDataFromService(queryString).ConfigureAwait(false);

            if (results != null)
            {
                User user = new User();
                user.Name = (string)results["name"];
                user.Email = (string)results["email"];

                JArray stats = (JArray)results["stat"];
                user.Stat = new float[stats.Count];

                for (int i = 0; i < stats.Count; i++)
                {
                    user.Stat[i] = (float)stats[i];
                }

                return user;
            }
            else
            {
                return null;
            }

        }
    }
}
