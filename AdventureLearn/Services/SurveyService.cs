using AdventureLearn.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp;

namespace AdventureLearn.Services
{
    public class SurveyService
    {
        // Get all list of surveys
        public static async Task<List<Survey>> GetSurveys()
        {
            string queryString = "Survey";
            dynamic results = await DataService.GetDataFromService(queryString).ConfigureAwait(false);

            if (results != null)
            {
                List<Survey> surveys = new List<Survey>();

                foreach (var r in results)
                {
                    surveys.Add(AssignSurvey(r));
                }

                return surveys;
            }

            return null;
        }

        // Get a survey based on number
        public static async Task<Survey> GetSurvey(string no)
        {
            string queryString = "Survey/" + no;

            dynamic results = await DataService.GetDataFromService(queryString).ConfigureAwait(false);

            if (results != null)
            {
                return AssignSurvey(results);
            }
            else
            {
                return null;
            }
        }

        // Assign a survey to results
        private static Survey AssignSurvey(dynamic results)
        {
            Survey survey = new Survey();
            List<Question> questions = new List<Question>();
            survey.No = (string)results["no"];
            survey.Title = (string)results["title"];

            foreach (var qns in results["questions"])
            {
                Question question = new Question();
                question.Qns = qns["qns"];

                JArray options = (JArray)qns["options"];
                question.Options = new string[options.Count];

                for (int i = 0; i < options.Count; i++)
                {
                    question.Options[i] = (string)options[i];
                }

                questions.Add(question);
            }

            survey.Questions = questions.ToArray();

            return survey;
        }
    }
}
