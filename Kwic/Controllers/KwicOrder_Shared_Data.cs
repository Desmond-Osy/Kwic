using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kwic.Controllers
{
    public class KwicOrder_Shared_Data : IComparer<Pair>
    {
        private char[] charInput;
        char space = ' ', carriage_return = '\r', new_line = '\n';

        public KwicOrder_Shared_Data(char[] input)
        {
            charInput = input;
        }

        public int Compare(Pair a, Pair b)
        {
            var indexA = a.getFirst() + a.getOffset();
            var indexB = b.getFirst() + b.getOffset();

            var firstIteration = true;

            var indexAStart = indexA;
            var indexBStart = indexB;

            while (true)
            {
                while (charInput[indexA] == carriage_return || charInput[indexA] == new_line || charInput[indexA] == space)
                {
                    indexA = GoNextIndex(indexA, a);
                }
                while (charInput[indexB] == carriage_return || charInput[indexB] == new_line || charInput[indexB] == space)
                {
                    indexB = GoNextIndex(indexB, b);
                }

                if (!firstIteration && indexA == indexAStart && indexB == indexBStart)
                {
                    return 0;
                }

                if (charInput[indexA] == charInput[indexB])
                {
                    indexA = GoNextIndex(indexA, a);
                    indexB = GoNextIndex(indexB, b);
                }
                else
                {
                    int comparisonInteger = char.ToUpperInvariant(charInput[indexA]).CompareTo(char.ToUpperInvariant(charInput[indexB]));

                    if (char.ToUpperInvariant(charInput[indexA]) == char.ToUpperInvariant(charInput[indexB]))
                    {
                        comparisonInteger = charInput[indexA].CompareTo(charInput[indexB]);
                        return comparisonInteger * -1;
                    }

                    return comparisonInteger;
                }

                firstIteration = false;
            }
        }
        private int GoNextIndex(int currentIndex, Pair index)
        {
            var nextIndex = currentIndex + 1;

            // if at the end of the line, go to the front
            if (nextIndex >= charInput.Length || charInput[nextIndex] == carriage_return || charInput[nextIndex] == new_line)
            {
                return index.getFirst();
            }
            return nextIndex;
        }
    }
}
