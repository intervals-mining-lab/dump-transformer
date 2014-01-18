using System.Collections.Generic;
using System.Linq;

namespace DumpTransformer.Cleaners
{
    public class CommentsCleaner : ITransformer
    {
        public List<string> CleanUp(List<string> input)
        {
            return input.Where(a => !a.StartsWith("--")).ToList();
        }
    }
}
