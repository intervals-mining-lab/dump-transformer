﻿namespace DumpTransformerTest
{
    using System.Collections.Generic;

    using DumpTransformer;

    using NUnit.Framework;

    /// <summary>
    /// The assembler test.
    /// </summary>
    [TestFixture]
    public class AssemblerTest
    {
        /// <summary>
        /// The assemble test.
        /// </summary>
        [Test]
        public void AssembleTest()
        {
            string[] structureTest = new[]
                {
                    "SELECT * FROM \"Cars\" a WHERE a.Cost = '1000';",
                    "-- test query"
                };
            
            string[] dataTest = new[]
                {
                    "SELECT pg_catalog.setval('nature_id_seq', 3, true);",
                    "SELECT pg_catalog.setval('nature_id_seq', 3, true);",
                    "SELECT pg_catalog.setval('note_symbol_id_seq', 7, true);",
                    "SELECT pg_catalog.setval('notation_id_seq', 9, true);"
                };
            string header = "Start Time Test";
            string footer = "End Time Test";
            var expected = new List<string>
                {
                    "--" + header,
                    "BEGIN;",
                    "SELECT * FROM \"Cars\" a WHERE a.Cost = '1000';",
                    "SELECT pg_catalog.setval('nature_id_seq', 3, true);",
                    "SELECT pg_catalog.setval('nature_id_seq', 3, true);",
                    "SELECT pg_catalog.setval('note_symbol_id_seq', 7, true);",
                    "SELECT pg_catalog.setval('notation_id_seq', 9, true);",
                    "COMMIT;",
                    "--" + footer
                };
            var assembler = new Assembler(header, footer);
            List<string> actual = assembler.Assemble(structureTest, dataTest);

            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < actual.Count; i++)
            {
                Assert.IsTrue(string.Equals(expected[i], actual[i]));
            }
        }
    }
}
