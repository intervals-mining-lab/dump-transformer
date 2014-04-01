namespace DumpTransformer.Cleaners
{
    using System.Collections.Generic;

    /// <summary>
    /// The begin commit adder.
    /// </summary>
    public class BeginCommitAdder : ITransformer
    {
        /// <summary>
        /// The header.
        /// </summary>
        private readonly string header;

        /// <summary>
        /// The footer.
        /// </summary>
        private readonly string footer;

        /// <summary>
        /// Initializes a new instance of the <see cref="BeginCommitAdder"/> class.
        /// </summary>
        /// <param name="header">
        /// The header.
        /// </param>
        /// <param name="footer">
        /// The footer.
        /// </param>
        public BeginCommitAdder(string header, string footer)
        {
            this.header = header;
            this.footer = footer;
        }

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
            input.Insert(0, "--" + this.header);
            input.Insert(1, "BEGIN;");
            input.Add("COMMIT;");
            input.Add("--" + this.footer);
            return input;
        }
    }
}
