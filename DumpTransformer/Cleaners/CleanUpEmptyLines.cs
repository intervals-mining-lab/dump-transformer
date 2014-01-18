using System.Collections.Generic;

namespace DumpTransformer.Cleaners
{
    public class CleanUpEmptyLines : ITransformer
    {
        public List<string> CleanUp(List<string> input)
        {
            bool nextIsEmpty = false;
            List<string> result = new List<string>();
            for (int i = 0; i < input.Count; i++)
            {
                if (!nextIsEmpty)
                {
                    result.Add(input[i]);
                    if (string.IsNullOrEmpty(input[i]))
                    {
                        nextIsEmpty = true;
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(input[i]))
                    {
                        result.Add(input[i]);
                        nextIsEmpty = false;
                    }
                }
            }
            return result;
        }
    }
}
