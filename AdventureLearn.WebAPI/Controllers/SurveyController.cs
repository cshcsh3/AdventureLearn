using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventureLearn.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdventureLearn.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Survey")]
    public class SurveyController : Controller
    {
        private readonly SurveyService _survey;

        public SurveyController()
        {
            _survey = new SurveyService();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new ObjectResult(_survey.GetSurveys());
        }

        [HttpGet("{no}")]
        public IActionResult Get(string no)
        {
            var survey = _survey.GetSurvey(no);
            if (survey == null)
            {
                return NotFound();
            }

            return new ObjectResult(survey);
        }
    }
}