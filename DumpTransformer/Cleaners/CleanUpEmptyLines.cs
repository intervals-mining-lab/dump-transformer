namespace DumpTransformer.Cleaners
{
    using System.Collections.Generic;

    /// <summary>
    /// The clean up empty lines.
    /// </summary>
    public class CleanUpEmptyLines : ITransformer
    {
        /// <summary>
        /// The clean up.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<string> CleanUp(List<string> input)
        {
            bool nextIsEmpty = false;
            var result = new List<string>();
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
