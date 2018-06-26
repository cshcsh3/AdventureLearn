using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureLearn.Data
{
    // TODO This part should be done in database
    public class TranslateScore
    {
        public float GetScore(string option)
        {
            if (option.Equals("Very much like me"))
            {
                return 5.0F;
            }
            else if (option.Equals("Mostly like me"))
            {
                return 4.0F;
            }
            else if (option.Equals("Somewhat like me"))
            {
                return 3.0F;
            }
            else if (option.Equals("Not much like me"))
            {
                return 2.0F;
            }
            else
            {
                return 1.0F;
            }
        }
    }
}
