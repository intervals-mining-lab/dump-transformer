namespace DumpTransformer.Cleaners
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The clean up constants.
    /// </summary>
    public class CleanUpConsts : ITransformer
    {
        /// <summary>
        /// The deletion constant sequence.
        /// </summary>
        private readonly string[] deletionConstantSequence =
            {
                "SET statement_timeout = 0;",
                "SET lock_timeout = 0;",
                "SET client_encoding = 'UTF8';",
                "SET standard_conforming_strings = on;",
                "SET check_function_bodies = false;",
                "SET client_min_messages = warning;",
                "SET search_path = public, pg_catalog;",
                "REVOKE ALL ON SCHEMA public FROM PUBLIC;",
                "REVOKE ALL ON SCHEMA public FROM postgres;",
                "GRANT ALL ON SCHEMA public TO postgres;",
                "GRANT ALL ON SCHEMA public TO PUBLIC;"
            };

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
            var result = new List<string>();
            foreach (var line in input)
            {
                bool isValid = this.deletionConstantSequence.All(delConst => !line.Contains(delConst));
                if (isValid)
                {
                    result.Add(line);
                }
            }

            return result;
        }
    }
}
