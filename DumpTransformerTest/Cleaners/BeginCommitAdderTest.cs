using System.Collections.Generic;
using NUnit.Framework;
using DumpTransformer.Cleaners;

namespace DumpTransformerTest.Cleaners
{
    [TestFixture]
    class BeginCommitAdderTest
    {
        [Test]
        public void CleanUpTest()
        {
            string header = "Start Time";
            string footer = "End Time";

            var input = new List<string>
                {
                    "SELECT pg_catalog.setval('nature_id_seq', 3, true);",
                    "SELECT pg_catalog.setval('note_symbol_id_seq', 7, true);",
                    "SELECT pg_catalog.setval('notation_id_seq', 9, true);"
                };

            var expected = new List<string>
                {
                    "--" + header,
                    "BEGIN;",
                    "SELECT pg_catalog.setval('nature_id_seq', 3, true);",
                    "SELECT pg_catalog.setval('note_symbol_id_seq', 7, true);",
                    "SELECT pg_catalog.setval('notation_id_seq', 9, true);",
                    "COMMIT;",
                    "--" + footer
                };
            var beginCommitAdder = new BeginCommitAdder(header, footer);
            List<string> actual = beginCommitAdder.CleanUp(input);
            
            Assert.AreEqual(expected.Count, actual.Count);

            for (int i = 0; i < actual.Count; i++)
            {
                Assert.True(string.Equals(expected[i], actual[i]));
            }
        }
    }
}
