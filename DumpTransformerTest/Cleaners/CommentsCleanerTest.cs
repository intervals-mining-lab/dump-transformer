namespace DumpTransformerTest.Cleaners
{
    using System.Collections.Generic;

    using DumpTransformer.Cleaners;

    using NUnit.Framework;

    /// <summary>
    /// The comments cleaner test.
    /// </summary>
    [TestFixture]
    public class CommentsCleanerTest
    {
        /// <summary>
        /// The clean up test.
        /// </summary>
        [Test]
        public void CleanUpTest()
        {
            var input = new List<string>
                {
                    "ALTER FUNCTION public.copy_triggers(srcoid oid, dstoid oid) OWNER TO postgres;",
                    "ALTER FUNCTION public.copy_constraints(src text, dst text) OWNER TO postgres;",
                    "--REVOKE ALL ON SCHEMA public FROM postgres;",
                    "--GRANT ALL ON SCHEMA public TO postgres;",
                    "SELECT pg_catalog.setval('note_symbol_id_seq', 7, true);",
                    "ALTER FUNCTION public.copy_triggers(srcoid oid, dstoid oid) OWNER TO postgres;",
                    "ALTER FUNCTION public.copy_indexes(src text, dst text) OWNER TO postgres;",
                    "SELECT pg_catalog.setval('notation_id_seq', 9, true);",
                    "--SET lock_timeout = 0;",
                    "ALTER FUNCTION public.copy_triggers(src text, dst text) OWNER TO postgres;",
                    "SET standard_conforming_strings = on;",
                    "--SET client_min_messages = warning;",
                    "--SET standard_conforming_strings = on;",
                    "--SET check_function_bodies = false;",
                    "--SET client_min_messages = warning;",
                    "SET search_path = public, pg_catalog;",
                    "REVOKE ALL ON SCHEMA public FROM PUBLIC;",
                    "--SET standard_conforming_strings = on;",
                    "--",
                    "-- ",
                    "--Test Test test"
                };

            var expected = new List<string>
                {
                    "ALTER FUNCTION public.copy_triggers(srcoid oid, dstoid oid) OWNER TO postgres;",
                    "ALTER FUNCTION public.copy_constraints(src text, dst text) OWNER TO postgres;",
                    "SELECT pg_catalog.setval('note_symbol_id_seq', 7, true);",
                    "ALTER FUNCTION public.copy_triggers(srcoid oid, dstoid oid) OWNER TO postgres;",
                    "ALTER FUNCTION public.copy_indexes(src text, dst text) OWNER TO postgres;",
                    "SELECT pg_catalog.setval('notation_id_seq', 9, true);",
                    "ALTER FUNCTION public.copy_triggers(src text, dst text) OWNER TO postgres;",
                    "SET standard_conforming_strings = on;",
                    "SET search_path = public, pg_catalog;",
                    "REVOKE ALL ON SCHEMA public FROM PUBLIC;",
                };
            var cleanUpComments = new CleanUpComments();
            List<string> actual = cleanUpComments.CleanUp(input);
            
            Assert.AreEqual(expected.Count, actual.Count);

            for (int i = 0; i < actual.Count; i++)
            {
                Assert.True(string.Equals(expected[i], actual[i]));
            }
        }
    }
}
