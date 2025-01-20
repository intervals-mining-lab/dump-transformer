namespace DumpTransformer.Tests
{
    using System.Collections.Generic;

    using DumpTransformer;

    using NUnit.Framework;

    /// <summary>
    /// The assembler tests.
    /// </summary>
    [TestFixture]
    public class AssemblerTests
    {
        /// <summary>
        /// The assemble test.
        /// </summary>
        [Test]
        public void AssembleTest()
        {
            string[] structureTest = 
                {
                    "SELECT * FROM \"Cars\" a WHERE a.Cost = '1000';",
                    "-- test query",
                    "SELECT pg_catalog.setval('nature_id_seq', 3, true);",
                    "SELECT pg_catalog.setval('nature_id_seq', 3, true);",
                    "SELECT pg_catalog.setval('note_symbol_id_seq', 7, true);",
                    "SELECT pg_catalog.setval('notation_id_seq', 9, true);"
                };

            const string Header = "Start Time Test";
            const string Footer = "End Time Test";
            string[] expected =
                {
                    "--" + Header,
                    "BEGIN;",
                    "SELECT * FROM \"Cars\" a WHERE a.Cost = '1000';",
                    "SELECT pg_catalog.setval('nature_id_seq', 3, true);",
                    "SELECT pg_catalog.setval('nature_id_seq', 3, true);",
                    "SELECT pg_catalog.setval('note_symbol_id_seq', 7, true);",
                    "SELECT pg_catalog.setval('notation_id_seq', 9, true);",
                    "COMMIT;",
                    "--" + Footer
                };

            var assembler = new Assembler(Header, Footer);
            List<string> actual = assembler.Assemble(structureTest);

            Assert.That(expected, Has.Length.EqualTo(actual.Count));
            for (int i = 0; i < actual.Count; i++)
            {
                Assert.That(expected[i], Is.EqualTo(actual[i]));
            }
        }
    }
}
