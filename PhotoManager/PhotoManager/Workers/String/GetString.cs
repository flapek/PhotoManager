using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PhotoManager.Workers.String
{
    class GetString
    {
        private static string pattern = @"[a-zA-Z0-9!@#$%^&*()_-]*\..*";

        public static string OneStringFromPath(string s)
        {
            Regex regex = new Regex(pattern);

            return regex.Match(s).ToString();
        }

        public static async Task<string[]> StringListFromPathListTask(string[] stringArray)
        {
            Regex regex = new Regex(pattern);

            List<string> list = new List<string>();

            foreach (string s in stringArray)
            {
                Match match = regex.Match(s);
                list.Add(match.Value);
            }

            return list.ToArray();
        }
    }
}
