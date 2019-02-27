using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kwic.Controllers
{
    public class KwicPipeLine : PipeLine<IEnumerable<String>>
    {

            public override IEnumerable<String> Process(IEnumerable<String> input)
            {
                foreach (var filter in filters)
                {
                    input = filter.Execute(input);
                }

                return input;
            }
        }

}
