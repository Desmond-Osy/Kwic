using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kwic.Controllers
{
    public class KwicOrder : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            int compare = x[0].ToString().ToLower().CompareTo(y[0].ToString().ToLower());
            int compareTwo = x.ToLower().CompareTo(y.ToLower());
            int result = x.CompareTo(y);
            if (compareTwo != 0)
            {
                return compareTwo;
            }
            if (result < 0)
            {
                return -1;
            }
            else if (result == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
