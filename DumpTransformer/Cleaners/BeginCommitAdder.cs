using System;
using System.Collections.Generic;

namespace DumpTransformer.Cleaners
{
    public class BeginCommitAdder : ITransformer
    {
        private readonly string header;
        private readonly string footer;

        public BeginCommitAdder(string header, string footer)
        {
            this.header = header;
            this.footer = footer;
        }

        public List<string> CleanUp(List<string> input)
        {
            input.Insert(0, "--" + header);
            input.Insert(1, "BEGIN;");
            input.Add("COMMIT;");
            input.Add("--" + footer);
            return input;
        }
    }
}
