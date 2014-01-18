using System.Collections.Generic;
using System.Linq;

namespace DumpTransformer.Cleaners
{
    public class CleanUpTemplates : ITransformer
    {
        private const string startsWith = "ALTER ";
        private const string endsWith = "OWNER TO postgres;";

        public List<string> CleanUp(List<string> input)
        {
            return input.Where(i => !(i.StartsWith(startsWith) && i.EndsWith(endsWith))).ToList();
        }
    }
}
