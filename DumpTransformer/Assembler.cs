namespace DumpTransformer
{
    using System.Collections.Generic;

    using DumpTransformer.Cleaners;

    /// <summary>
    /// The assembler.
    /// </summary>
    public class Assembler
    {
        /// <summary>
        /// The transformers.
        /// </summary>
        private readonly List<ITransformer> transformers;

        /// <summary>
        /// Initializes a new instance of the <see cref="Assembler"/> class.
        /// </summary>
        /// <param name="header">
        /// The header.
        /// </param>
        /// <param name="footer">
        /// The footer.
        /// </param>
        public Assembler(string header, string footer)
        {
            this.transformers = new List<ITransformer>
            {
                new CleanUpComments(),
                new CleanUpConsts(),
                new CleanUpTemplates(),
                new CleanUpEmptyLines(),
                new BeginCommitAdder(header, footer)
            };
        }

        /// <summary>
        /// The assemble.
        /// </summary>
        /// <param name="databsebStructure">
        /// The database structure.
        /// </param>
        /// <param name="databaseData">
        /// The database data.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<string> Assemble(string[] databsebStructure)
        {
            var result = new List<string>(databsebStructure);
            foreach (var transformer in this.transformers)
            {
                result = transformer.CleanUp(result);
            }

            return result;
        }
    }
}
