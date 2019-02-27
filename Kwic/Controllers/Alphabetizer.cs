using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kwic.Controllers
{
    public class Alphabetizer : IFilter<IEnumerable<String>>
    {
        public IEnumerable<String> Execute(IEnumerable<String> input)
        {
            return input.OrderBy(s => s, new KwicOrder2());     
        }
    }
}
