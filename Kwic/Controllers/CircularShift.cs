using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kwic.Controllers
{
    public class CircularShift : IFilter<IEnumerable<String>>
    {
        public IEnumerable<String> Execute(IEnumerable<String> input)
        {
            List<String> result = new List<string>();
            Boolean first = true;
            int currentSize = 0;

            foreach(String sentence in input)
            {
                var words = sentence.Split(' ');
                for (int j = 0; j < words.Length; j++)
                {
                    if (first)
                    {
                        string res = words[words.Length - 1];
                        for (int i = 0; i < words.Length - 1; i++)
                        {
                            res = res + " " + words[i];
                        }
                        result.Add(res);
                        first = false;
                    }
                    else
                    {
                        words = result[j-1+currentSize].Split(' ');
                        string res = words[words.Length - 1];
                        for (int i = 0; i < words.Length - 1; i++)
                        {
                            res = res + " " + words[i];
                        }
                        result.Add(res);
                    }
                }
                currentSize = result.Count;
                first = true;
            }
            return result;
        }

    }
}
