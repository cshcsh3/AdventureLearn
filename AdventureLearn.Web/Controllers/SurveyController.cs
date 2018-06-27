using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventureLearn.Data;
using AdventureLearn.Models;
using AdventureLearn.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdventureLearn.Web.Controllers
{
    public class SurveyController : Controller
    {
        public async Task<IActionResult> Welcome()
        {
            var model = new List<Survey>();
            var surveys = await SurveyService.GetSurveys();

            for (var i = 0; i < surveys.Count; i++)
            {
                model.Add(surveys[i]);
            }
            
            return View(model);
        }
        
        public async Task<IActionResult> TakeSurvey(string id)
        {
            Survey survey = await SurveyService.GetSurvey(id);        
            return View("Survey", survey);
        }
        
        [HttpPost]
        public async Task<IActionResult> SubmitSurvey(string id) {
            Survey survey = await SurveyService.GetSurvey(id);

            List<String> selectedRadios = new List<string>();
            Dictionary<int, String> selectedOptions = new Dictionary<int, String>();

            var i = 0;
            foreach (var question in survey.Questions)
            {
                i++;
                var qns = "qns" + i;
                selectedRadios.Add(qns);
            }

            // Obtains selected radio item value and stores in dictionary
            var j = 0;
            foreach (String radio in selectedRadios) {
                selectedOptions.Add(j, Request.Form[radio]);
                j++;
            }

            GenerateResult generateResult = new GenerateResult(selectedOptions);
            ViewBag.score = generateResult.GetGritScore();
            ViewBag.message = generateResult.GetGritMessage();

            return View("Result");
        }
    }
}