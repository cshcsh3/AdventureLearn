using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureLearn.Models
{
    public class Survey
    {
        public string No { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Set { get; set; }
        public Question[] Questions { get; set; }
    }
}
