using System.Collections.Generic;
using NUnit.Framework;
using DumpTransformer.Cleaners;

namespace DumpTransformerTest.Cleaners
{
    [TestFixture]
    class CleanUpEmptyLinesTest
    {
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
            var cleanUpEmptyLines = new CleanUpEmptyLines();
            List<string> actual = cleanUpEmptyLines.CleanUp(input);
            
            Assert.AreEqual(expected.Count, actual.Count);

            for (int i = 0; i < actual.Count; i++)
            {
                Assert.True(string.Equals(expected[i], actual[i]));
            }
        }
    }
}
