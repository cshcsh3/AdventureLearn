using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureLearn.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public float[] Stat { get; set; }
    }
}
