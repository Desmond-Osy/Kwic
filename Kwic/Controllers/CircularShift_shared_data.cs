using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kwic.Controllers
{
    public class CircularShift_shared_data 
    {
        public List<Pair> shift(char[] input)
        {
            var offsets = new List<Pair>();
            var currentOffset = 0;
            var first = 0; 



            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ' ')
                {
                    offsets.Add(new Pair(first, currentOffset));
                    while (i < input.Length && (input[i] == '\r' || input[i] == ' ' || input[i] == '\n'))
                    {
                        i++;
                    }

                    currentOffset = i - first;
                }
  
                else if (input[i] == '\r' || input[i] == '\n')
                {
                    offsets.Add(new Pair(first, currentOffset));
                    while (i < input.Length && (input[i] == '\r' || input[i] == ' ' || input[i] == '\n'))
                    {
                        i++;
                    }

                    first = i;
                    currentOffset = 0;
                }

            }

            offsets.Add(new Pair(first, currentOffset));
            return offsets;
        }

    }
}
