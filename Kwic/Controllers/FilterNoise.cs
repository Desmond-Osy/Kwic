using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kwic.Controllers
{
    public class FilterNoise
    {
        private static String noiseString = "a an the and or of to be is in out by as at off";
        private List<String> noiseWords = noiseString.Split(' ').ToList();
        public IEnumerable<String> filter(List<String> input)
        {

            foreach (String p in input.ToList())
            {
                String firstWord = getFirstWord(p);
                if (isNoiseWord(firstWord))
                {
                    input.Remove(p);
                }
            }

            return input;
        }

        private String getFirstWord(String input)
        {
            int i = 0;
            while (input[i] != ' ')
            {
                i++;
            }
            return input.Substring(0, i);
        }

        private bool isNoiseWord(String input)
        {
            foreach(String noise in noiseWords)
            {
                if (noise.Equals(input))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
