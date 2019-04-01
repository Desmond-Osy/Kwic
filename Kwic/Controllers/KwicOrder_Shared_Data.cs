using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kwic.Controllers
{
    public class KwicOrder_Shared_Data : IComparer<Pair>
    {
        private readonly char[] _input;

        public KwicOrder_Shared_Data(char[] input)
        {
            _input = input;
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
                while (_input[indexA] == '\r' || _input[indexA] == '\n' || _input[indexA] == ' ')
                {
                    indexA = GoNextIndex(indexA, a);
                }
                while (_input[indexB] == '\r' || _input[indexB] == '\n' || _input[indexB] == ' ')
                {
                    indexB = GoNextIndex(indexB, b);
                }

                if (!firstIteration && indexA == indexAStart && indexB == indexBStart)
                {
                    return 0;
                }

                if (_input[indexA] == _input[indexB])
                {
                    indexA = GoNextIndex(indexA, a);
                    indexB = GoNextIndex(indexB, b);
                }
                else
                {
                    int comparisonInteger = char.ToUpperInvariant(_input[indexA]).CompareTo(char.ToUpperInvariant(_input[indexB]));

                    // same character
                    if (char.ToUpperInvariant(_input[indexA]) == char.ToUpperInvariant(_input[indexB]))
                    {
                        comparisonInteger = _input[indexA].CompareTo(_input[indexB]);
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
            if (nextIndex >= _input.Length || _input[nextIndex] == '\r' || _input[nextIndex] == '\n')
            {
                return index.getFirst();
            }
            return nextIndex;
        }
    }
}
