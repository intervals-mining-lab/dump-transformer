using System;
using System.Collections.Generic;
using DumpTransformer.Cleaners;

namespace DumpTransformer
{
    public class Assembler
    {
        private readonly List<ITransformer> transformers;

        public Assembler(string header, string footer)
        {
            transformers = new List<ITransformer>
            {
                new CleanUpComments(),
                new CleanUpConsts(),
                new CleanUpTemplates(),
                new CleanUpEmptyLines(),
                new BeginCommitAdder(header, footer)
            };
        }

        public List<string> Assemble(string[] dBStructure, string[] dBData)
        {
            var result = new List<string>(dBStructure);
            result.AddRange(dBData);
            foreach (var transformer in transformers)
            {
                result = transformer.CleanUp(result);
            }
            return result;
        }
    }
}
