using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace krekvirus
{
    internal class timeSpanToString
    {
        public static string toString(TimeSpan diffTime)
        {
            return diffTime.Days + " days, " + diffTime.Hours + " hours, and " + diffTime.Minutes + " minutes";
        }
    }
}
