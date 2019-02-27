using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kwic.Controllers
{
    public class KwicOrder2 : IComparer<string>
    {
        const String ORDER= "aAbBcCdDeEfFgGhHiIjJkKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ";

        public int Compare(string x, string y)
        {
            int pos1 = 0;
            int pos2 = 0;
            for (int i = 0; i < Math.Min(x.Length, y.Length) && pos1 == pos2; i++)
            {
                pos1 = ORDER.IndexOf(x[i]);
                pos2 = ORDER.IndexOf(y[i]);
            }

            if (pos1 == pos2 && x.Length != y.Length)
            {
                return x.Length - y.Length;
            }

            return pos1 - pos2;
        }
    }
}
