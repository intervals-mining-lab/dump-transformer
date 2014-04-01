namespace DumpTransformer.Tests.Cleaners
{
    using System.Collections.Generic;

    using DumpTransformer.Cleaners;

    using NUnit.Framework;

    /// <summary>
    /// The clean up empty lines tests.
    /// </summary>
    [TestFixture]
    public class CleanUpEmptyLinesTests : CleanerAbstractTests
    {
        /// <summary>
        /// The clean up test.
        /// </summary>
        [Test]
        public void CleanUpTest()
        {
            var input = new List<string>
                {
                    "GRANT ALL ON SCHEMA public TO postgres;",
                    "",
                    "REVOKE ALL ON SCHEMA public FROM postgres;",
                    "GRANT ALL ON SCHEMA public TO postgres;",
                    "",
                    "",
                    "",
                    "SELECT pg_catalog.setval('notation_id_seq', 9, true);",
                    "",
                    "SET client_min_messages = warning;",
                    "SET standard_conforming_strings = on;",
                    "SET client_min_messages = warning;",
                    "SET standard_conforming_strings = on;",
                    "",
                    "",
                    "SET search_path = public, pg_catalog;",
                    "",
                    "SET standard_conforming_strings = on;",
                };

            var expected = new List<string>
                {
                    "GRANT ALL ON SCHEMA public TO postgres;",
                    "",
                    "REVOKE ALL ON SCHEMA public FROM postgres;",
                    "GRANT ALL ON SCHEMA public TO postgres;",
                    "",
                    "SELECT pg_catalog.setval('notation_id_seq', 9, true);",
                    "",
                    "SET client_min_messages = warning;",
                    "SET standard_conforming_strings = on;",
                    "SET client_min_messages = warning;",
                    "SET standard_conforming_strings = on;",
                    "",
                    "SET search_path = public, pg_catalog;",
                    "",
                    "SET standard_conforming_strings = on;",
                };

            this.CleanUpTest(new CleanUpEmptyLines(), input, expected);
        }
    }
}
