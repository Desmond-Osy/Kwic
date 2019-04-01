using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kwic.Controllers
{
    public class Pair
    {
        private int first;
        private int offset;

        public Pair(int first, int offset)
        {
            this.first = first;
            this.offset = offset;
        }

        public int getOffset()
        {
            return offset;
        }

        public int getFirst()
        {
            return first;
        }
    }
}
