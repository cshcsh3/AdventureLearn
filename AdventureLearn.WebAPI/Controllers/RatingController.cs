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
    [Route("api/Rating")]
    public class RatingController : Controller
    {
        private readonly RatingService _rating;

        public RatingController() {
            _rating = new RatingService();
        }

        [HttpGet("{set}")]
        public IActionResult Get(string set)
        {
            var rating = _rating.GetRating(set);
            if (rating == null)
            {
                return NotFound();
            }

            return new ObjectResult(rating);
        }
    }
}