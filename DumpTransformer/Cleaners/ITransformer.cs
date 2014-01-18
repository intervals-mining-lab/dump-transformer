using System.Collections.Generic;

namespace DumpTransformer.Cleaners
{
    public interface ITransformer
    {
        List<string> CleanUp(List<string> input);
    }
}
