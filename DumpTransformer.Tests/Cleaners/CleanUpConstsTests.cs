namespace DumpTransformer.Tests.Cleaners
{
    using System.Collections.Generic;

    using DumpTransformer.Cleaners;

    using NUnit.Framework;

    /// <summary>
    /// The clean up constants tests.
    /// </summary>
    [TestFixture]
    public class CleanUpConstsTests : CleanerAbstractTests
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
                    "SELECT pg_catalog.setval('nature_id_seq', 3, true);",
                    "REVOKE ALL ON SCHEMA public FROM postgres;",
                    "GRANT ALL ON SCHEMA public TO postgres;",
                    "SELECT pg_catalog.setval('note_symbol_id_seq', 7, true);",
                    "SET client_min_messages = warning;",
                    "SET standard_conforming_strings = on;",
                    "SELECT pg_catalog.setval('notation_id_seq', 9, true);",
                    "SET lock_timeout = 0;",
                    "SET client_min_messages = warning;",
                    "SET standard_conforming_strings = on;",
                    "SET client_min_messages = warning;",
                    "SET standard_conforming_strings = on;",
                    "SET check_function_bodies = false;",
                    "SET client_min_messages = warning;",
                    "SET search_path = public, pg_catalog;",
                    "REVOKE ALL ON SCHEMA public FROM PUBLIC;",
                    "SET standard_conforming_strings = on;",
                };

            var expected = new List<string>
                {
                    "SELECT pg_catalog.setval('nature_id_seq', 3, true);",
                    "SELECT pg_catalog.setval('note_symbol_id_seq', 7, true);",
                    "SELECT pg_catalog.setval('notation_id_seq', 9, true);"
                };

            this.CleanUpTest(new CleanUpConsts(), input, expected);
        }
    }
}
