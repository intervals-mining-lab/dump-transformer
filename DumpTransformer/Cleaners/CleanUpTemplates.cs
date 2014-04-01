namespace DumpTransformer.Cleaners
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The clean up templates.
    /// </summary>
    public class CleanUpTemplates : ITransformer
    {
        /// <summary>
        /// The starts with.
        /// </summary>
        private const string StartsWith = "ALTER ";

        /// <summary>
        /// The ends with.
        /// </summary>
        private const string EndsWith = "OWNER TO postgres;";

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
            return input.Where(i => !(i.StartsWith(StartsWith) && i.EndsWith(EndsWith))).ToList();
        }
    }
}
