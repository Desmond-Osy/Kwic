using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kwic.Controllers
{
    public class OutputProcessor
    {
        private char[] charInput;
        char space = ' ', carriage_return = '\r', new_line = '\n';

        public void SetInput(char[] input)
        {
            this.charInput = input;
        }

        public List<string> GetStringListFromIndices(IEnumerable<Pair> indices)
        {
            var result = new List<string>();
            foreach (var index in indices)
            {
                result.Add(GenerateStringLine(index));
            }

            return result;
        }

        public string GetStringFromIndices(IEnumerable<Pair> indices)
        {
            var stringBuilder = new StringBuilder();
            foreach (var index in indices)
            {
                stringBuilder.Append(GenerateStringLine(index));
                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }

        private string GenerateStringLine(Pair index)
        {
            var stringBuilder = new StringBuilder();

            var first = index.getFirst();
            var offset = index.getOffset();
            var i = first + offset;
            var k = first;

            while (i != charInput.Length && charInput[i] != carriage_return && charInput[i] != new_line)
            {
                stringBuilder.Append(charInput[i]);
                i++;
            }

            if (offset != 0)
            {
                stringBuilder.Append(space);
            }

            while (k < first + offset - 1)
            {
                stringBuilder.Append(charInput[k]);
                k++;
            }
            return stringBuilder.ToString();
        }
    }
}
