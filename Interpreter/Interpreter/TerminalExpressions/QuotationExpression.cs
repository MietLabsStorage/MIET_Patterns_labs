using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Interpreter.TerminalExpressions
{
    public class QuotationExpression : IExpression
    {
        public bool Interpret(ref string context)
        {
            /*string pattern = "\".*\"";
            Regex regex = new Regex(pattern);
            foreach (Match match in regex.Matches(context))
            {
                Console.WriteLine("+++");
                string newStr = context.Trim(new char[] {'\"'});
                context = context.Replace(match.Value, $"<<{newStr}>>");
            }*/
            List<string> substrs = new List<string>();
            substrs.AddRange(context.Split(new char[] { '\"' }));
            StringBuilder str = new StringBuilder(substrs[0]);
            for (int i = 1; i < substrs.Count; i++)
            {
                str.Append(((i % 2 == 0) ? "»" : "«") + substrs[i]);
            }

            context = str.ToString();
            return false;
        }
    }
}