using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DumpTransformer;
using NUnit.Framework;

namespace DumpTransformerTest
{
    [TestFixture]
    public class TransformerTest
    {
        [Test]
        public void AssembleTest()
        {
            string[] structureTest = new []
                {
                    "SELECT * FROM \"Cars\" a WHERE a.Cost = '1000';",
                    "-- test query"
                };
            
            string[] dataTest = new []
                {
                    "SELECT pg_catalog.setval('nature_id_seq', 3, true);",
                    "SELECT pg_catalog.setval('nature_id_seq', 3, true);",
                    "SELECT pg_catalog.setval('note_symbol_id_seq', 7, true);",
                    "SELECT pg_catalog.setval('notation_id_seq', 9, true);"
                };

            List<string> expected = new List<string>
                {
                    "SELECT * FROM \"Cars\" a WHERE a.Cost = '1000';",
                    "-- test query",
                    "SELECT pg_catalog.setval('nature_id_seq', 3, true);",
                    "SELECT pg_catalog.setval('nature_id_seq', 3, true);",
                    "SELECT pg_catalog.setval('note_symbol_id_seq', 7, true);",
                    "SELECT pg_catalog.setval('notation_id_seq', 9, true);"
                };
            
            List<string> actual = Transformer.Assemble(structureTest, dataTest);

            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < actual.Count; i++)
            {
                Assert.IsTrue(string.Equals(expected[i], actual[i]));
            }
        }

        [Test]
        public void CleanUp()
        {
            
        }

    }
}
