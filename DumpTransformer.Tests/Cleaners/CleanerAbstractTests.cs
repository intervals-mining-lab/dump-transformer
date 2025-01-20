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

            Assert.That(expected, Has.Count.EqualTo(actual.Count));

            for (int i = 0; i < actual.Count; i++)
            {
                Assert.That(expected[i], Is.EqualTo(actual[i]));
            }
        }
    }
}
