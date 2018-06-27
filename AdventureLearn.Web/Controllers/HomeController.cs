using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdventureLearn.Web.Models;
using AdventureLearn.Models;
using AdventureLearn.Services;

namespace AdventureLearn.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // TODO: Account authentication
        [HttpPost]
        public async Task<IActionResult> Login(User values)
        {
            User user = await UserService.GetUser(values.Email);

            if (user != null)
            {
                ViewBag.name = user.Name;
                var model = new List<Survey>();
                var surveys = await SurveyService.GetSurveys();

                for (var i = 0; i < surveys.Count; i++)
                {
                    model.Add(surveys[i]);
                }

                return View("~/Views/Survey/Welcome.cshtml", model);
            }
            
            return View("Index");
        }
        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
