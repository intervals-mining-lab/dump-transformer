using System.Collections.Generic;
using System.Linq;

namespace DumpTransformer.Cleaners
{
    public class CleanUpConsts : ITransformer
    {
        private readonly string[] deletionConstSeq =
            {
                "SET statement_timeout = 0;",
                "SET lock_timeout = 0;",
                "SET client_encoding = 'UTF8';",
                "SET standard_conforming_strings = on;",
                "SET check_function_bodies = false;",
                "SET client_min_messages = warning;",
                "SET search_path = public, pg_catalog;",
                "REVOKE ALL ON SCHEMA public FROM PUBLIC;",
                "REVOKE ALL ON SCHEMA public FROM postgres;",
                "GRANT ALL ON SCHEMA public TO postgres;",
                "GRANT ALL ON SCHEMA public TO PUBLIC;"
            };
        
        public List<string> CleanUp(List<string> input)
        {
            var result = new List<string>();
            foreach (var line in input)
            {
                bool isValid = deletionConstSeq.All(delConst => !line.Contains(delConst));
                if (isValid)
                {
                    result.Add(line);
                }
            }
            return result;
        }
    }
}
