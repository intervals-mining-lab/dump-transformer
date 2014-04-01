namespace DumpTransformer.Cleaners
{
    using System.Collections.Generic;

    /// <summary>
    /// The Transformer interface.
    /// </summary>
    public interface ITransformer
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
        List<string> CleanUp(List<string> input);
    }
}
