using AdventureLearn.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp;

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

                return user;
            }
            else
            {
                return null;
            }

        }
    }
}
