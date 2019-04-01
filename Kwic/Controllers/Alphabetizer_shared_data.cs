using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kwic.Controllers
{
    public class Alphabetizer_shared_data 
    {
        public List<Pair> alphabetize (List<Pair> shiftedInput, char[] charInput)
        {
            return shiftedInput.OrderBy(s => s, new KwicOrder_Shared_Data(charInput)).ToList();     
        }
    }
}
