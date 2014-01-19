using System.Collections.Generic;
using NUnit.Framework;
using DumpTransformer.Cleaners;

namespace DumpTransformerTest.Cleaners
{
    [TestFixture]
    class CleanUpConstsTest
    {
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
            var cleanUpConsts = new CleanUpConsts();
            List<string> actual = cleanUpConsts.CleanUp(input);
            
            Assert.AreEqual(expected.Count, actual.Count);

            for (int i = 0; i < actual.Count; i++)
            {
                Assert.True(string.Equals(expected[i], actual[i]));
            }
        }
    }
}
