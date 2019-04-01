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
            
            int offset = 0;
            int first = 0; 
            List<Pair> result = new List<Pair>();
            char space = ' ', carriage_return = '\r', new_line = '\n';


            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == space)
                {
                    result.Add(new Pair(first, offset));
                    while (i < input.Length && (input[i] == carriage_return || input[i] == space || input[i] == new_line))
                    {
                        i++;
                    }

                    offset = i - first;
                }
  
                else if (input[i] == carriage_return || input[i] == new_line)
                {
                    result.Add(new Pair(first, offset));
                    while (i < input.Length && (input[i] == carriage_return || input[i] == space || input[i] == new_line))
                    {
                        i++;
                    }

                    first = i;
                    offset = 0;
                }

            }

            result.Add(new Pair(first, offset));
            return result;
        }

    }
}
