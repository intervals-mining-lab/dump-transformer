using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpTransformer
{
    public static class Transformer
    {
        private static string[] deletionSeq = {"SET statement_timeout = 0; SET lock_timeout = 0;SET client_encoding = 'UTF8';SET standard_conforming_strings = on;SET check_function_bodies = false;SET client_min_messages = warning;",
                                              "SET search_path = public, pg_catalog;",
                                              "REVOKE ALL ON SCHEMA public FROM PUBLIC;REVOKE ALL ON SCHEMA public FROM postgres;GRANT ALL ON SCHEMA public TO postgres;GRANT ALL ON SCHEMA public TO PUBLIC;",
                                              "ALTER TABLE",
                                              "OWNER TO postgres;"};
        public static List<string> Assemble(string[] dBStructure, string[] dBData)
        {
            var result = new List<string>(dBStructure);
            result.AddRange(dBData);
            return result;
        }

        public static List<string> CleanUp(List<string> assemblied)
        {
            List<string> withoutComments = assemblied.Where(l => !l.StartsWith("--")).ToList();
            bool nextIsEmpty = false;
            List<string> result = new List<string>();
            for (int i = 0; i < withoutComments.Count; i++)
            {
                if (!nextIsEmpty)
                {
                    result.Add(withoutComments[i]);
                    if (string.IsNullOrEmpty(withoutComments[i]))
                    {
                        nextIsEmpty = true;
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(withoutComments[i]))
                    {
                        result.Add(withoutComments[i]);
                        nextIsEmpty = false;
                    }
                }
            }
            return result;
        }
    }
}
