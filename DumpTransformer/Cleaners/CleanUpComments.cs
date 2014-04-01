namespace DumpTransformer.Cleaners
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The clean up comments.
    /// </summary>
    public class CleanUpComments : ITransformer
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
            return input.Where(a => !a.StartsWith("--")).ToList();
        }
    }
}
