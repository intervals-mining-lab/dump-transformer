namespace DumpTransformer.Tests.Cleaners
{
    using System.Collections.Generic;

    using DumpTransformer.Cleaners;

    using NUnit.Framework;

    /// <summary>
    /// The cleaner abstract tests.
    /// </summary>
    public class CleanerAbstractTests
    {
        /// <summary>
        /// The clean up test.
        /// </summary>
        /// <param name="cleaner">
        /// The cleaner.
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <param name="expected">
        /// The expected.
        /// </param>
        public void CleanUpTest(ITransformer cleaner, List<string> input, List<string> expected)
        {
            List<string> actual = cleaner.CleanUp(input);

            Assert.AreEqual(expected.Count, actual.Count);

            for (int i = 0; i < actual.Count; i++)
            {
                Assert.True(string.Equals(expected[i], actual[i]));
            }
        }
    }
}