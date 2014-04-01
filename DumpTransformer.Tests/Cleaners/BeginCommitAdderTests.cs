namespace DumpTransformer.Tests.Cleaners
{
    using System.Collections.Generic;

    using DumpTransformer.Cleaners;

    using NUnit.Framework;

    /// <summary>
    /// The begin commit adder tests.
    /// </summary>
    [TestFixture]
    public class BeginCommitAdderTests : CleanerAbstractTests
    {
 /// <summary>
        /// The clean up test.
        /// </summary>
        [Test]
        public void CleanUpTest()
        {
            const string Header = "Start Time";
            const string Footer = "End Time";

            var input = new List<string>
                {
                    "SELECT pg_catalog.setval('nature_id_seq', 3, true);",
                    "SELECT pg_catalog.setval('note_symbol_id_seq', 7, true);",
                    "SELECT pg_catalog.setval('notation_id_seq', 9, true);"
                };

            var expected = new List<string>
                {
                    "--" + Header,
                    "BEGIN;",
                    "SELECT pg_catalog.setval('nature_id_seq', 3, true);",
                    "SELECT pg_catalog.setval('note_symbol_id_seq', 7, true);",
                    "SELECT pg_catalog.setval('notation_id_seq', 9, true);",
                    "COMMIT;",
                    "--" + Footer
                };
            
            this.CleanUpTest(new BeginCommitAdder(Header, Footer), input, expected);
        }
    }
}
